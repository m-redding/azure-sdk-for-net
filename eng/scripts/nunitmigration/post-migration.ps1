#Requires -Version 7.0
<#
.SYNOPSIS
    Finalizes an NUnit 4 migration batch by adding version overrides and removing temporary analyzer references.

.DESCRIPTION
    1. Adds NUnit 4 conditional version overrides to eng/Packages.Data.props for the given service directories
    2. Removes the temporary NUnit.Analyzers property and PackageReference from eng/Packages.Data.props
    3. Removes NUnit.Analyzers from the management plane ItemGroup in eng/Directory.Build.Common.targets
    4. Checks that no .csproj files were accidentally modified; reverts any that were

    Run this AFTER run-migration.ps1 and AFTER committing the .cs code changes.

.PARAMETER ServiceDirectories
    One or more service directory names (e.g., "core", "storage", "keyvault").

.PARAMETER RepoRoot
    Root of the azure-sdk-for-net repository. Defaults to git repo root.

.EXAMPLE
    .\post-migration.ps1 -ServiceDirectories core, template
#>
[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)]
    [string[]]$ServiceDirectories,

    [Parameter()]
    [string]$RepoRoot = (git rev-parse --show-toplevel 2>$null),

    [Parameter()]
    [switch]$SkipCommit
)

Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

if (-not $RepoRoot) {
    Write-Error "Could not determine repo root. Run this script from within the azure-sdk-for-net git repository."
    return
}

$RepoRoot = Resolve-Path $RepoRoot

$packagesPropsPath = Join-Path $RepoRoot "eng" "Packages.Data.props"
$targetsPath = Join-Path $RepoRoot "eng" "Directory.Build.Common.targets"

# --- Step 1: Add NUnit 4 conditional override to Packages.Data.props ---
Write-Host "Adding NUnit 4 version overrides to $packagesPropsPath..." -ForegroundColor Cyan

$propsContent = Get-Content $packagesPropsPath -Raw

# Build the condition string from service directories
$conditions = $ServiceDirectories | ForEach-Object {
    "`$(MSBuildProjectDirectory.Contains('\sdk\$_\'))"
}
$conditionExpr = $conditions -join " or "
$serviceLabel = $ServiceDirectories -join ", "

$overrideBlock = @"

  <!-- NUnit 4 migration: $serviceLabel -->
  <ItemGroup Condition="$conditionExpr">
    <PackageReference Update="NUnit" Version="4.4.0" />
    <PackageReference Update="NUnit3TestAdapter" Version="4.6.0" />
    <PackageReference Update="NUnit.Analyzers" Version="4.5.0" />
  </ItemGroup>
"@

# Check if an override for these exact services already exists
$alreadyExists = $true
foreach ($svc in $ServiceDirectories) {
    if ($propsContent -notmatch [regex]::Escape("NUnit 4 migration") -or $propsContent -notmatch [regex]::Escape("\sdk\$svc\")) {
        $alreadyExists = $false
        break
    }
}

if ($alreadyExists -and $ServiceDirectories.Count -eq 1) {
    Write-Host "  Override for $serviceLabel may already exist — adding anyway (review for duplicates)." -ForegroundColor Yellow
}

# Insert before the closing </Project> tag
$propsContent = $propsContent -replace '(</Project>\s*)$', "$overrideBlock`n`$1"
Write-Host "  Added conditional ItemGroup for: $serviceLabel" -ForegroundColor Green

# --- Step 2: Remove temporary NUnit.Analyzers from Packages.Data.props ---
Write-Host "Removing temporary NUnit.Analyzers references from $packagesPropsPath..." -ForegroundColor Cyan

# Remove the NUnitAnalyzersVersion property
if ($propsContent -match '<NUnitAnalyzersVersion>') {
    $propsContent = $propsContent -replace '\s*<NUnitAnalyzersVersion>[^<]+</NUnitAnalyzersVersion>\r?\n?', "`n"
    Write-Host "  Removed NUnitAnalyzersVersion property." -ForegroundColor Green
} else {
    Write-Host "  NUnitAnalyzersVersion property not found (already removed or not present)." -ForegroundColor DarkGray
}

# Remove the NUnit.Analyzers PackageReference Update line from the test ItemGroup
if ($propsContent -match 'PackageReference Update="NUnit\.Analyzers" Version="\$\(NUnitAnalyzersVersion\)"') {
    $propsContent = $propsContent -replace '\s*<PackageReference Update="NUnit\.Analyzers" Version="\$\(NUnitAnalyzersVersion\)"\s*/>\r?\n?', "`n"
    Write-Host "  Removed NUnit.Analyzers PackageReference from test ItemGroup." -ForegroundColor Green
} else {
    Write-Host "  NUnit.Analyzers PackageReference not found in test ItemGroup (already removed or not present)." -ForegroundColor DarkGray
}

Set-Content -Path $packagesPropsPath -Value $propsContent -NoNewline

# --- Step 3: Remove NUnit.Analyzers from Directory.Build.Common.targets ---
Write-Host "Removing NUnit.Analyzers from $targetsPath..." -ForegroundColor Cyan

$targetsContent = Get-Content $targetsPath -Raw

if ($targetsContent -match '<PackageReference Include="NUnit\.Analyzers"\s*/>') {
    $targetsContent = $targetsContent -replace '\s*<PackageReference Include="NUnit\.Analyzers"\s*/>\r?\n?', "`n"
    Set-Content -Path $targetsPath -Value $targetsContent -NoNewline
    Write-Host "  Removed NUnit.Analyzers from management plane test ItemGroup." -ForegroundColor Green
} else {
    Write-Host "  NUnit.Analyzers not found in Directory.Build.Common.targets (already removed or not present)." -ForegroundColor DarkGray
}

# --- Step 4: Check for accidental .csproj changes ---
Write-Host "`nChecking for accidental .csproj changes..." -ForegroundColor Cyan

$csprojChanges = git -C $RepoRoot diff --name-only -- "*.csproj" 2>$null
if ($csprojChanges) {
    Write-Warning "Found modified .csproj files — reverting to avoid unintended changes:"
    foreach ($file in $csprojChanges) {
        Write-Warning "  $file"
        git -C $RepoRoot checkout HEAD -- $file 2>$null
    }
    Write-Host "  Reverted all .csproj changes." -ForegroundColor Green
} else {
    Write-Host "  No .csproj files were modified. Good." -ForegroundColor Green
}

# --- Commit ---
if (-not $SkipCommit) {
    Write-Host "`nCommitting changes..." -ForegroundColor Cyan
    git -C $RepoRoot add $packagesPropsPath $targetsPath
    git -C $RepoRoot commit -m "Add NUnit 4.4.0 override for $serviceLabel"
    Write-Host "Committed post-migration changes." -ForegroundColor Green
} else {
    Write-Host "`nSkipping commit (-SkipCommit specified)." -ForegroundColor Yellow
}

Write-Host "`nPost-migration complete. Next steps:" -ForegroundColor Cyan
Write-Host "  1. Build and test: .\eng\scripts\nunitmigration\test-run-builds.ps1 -ServiceDirectories $($ServiceDirectories -join ', ')" -ForegroundColor White
Write-Host "  2. Fix any build errors manually" -ForegroundColor White
Write-Host "  3. Push and create PR" -ForegroundColor White
