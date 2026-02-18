[CmdletBinding()]
param(
    [Parameter()]
    [string]$RepoRoot = (git rev-parse --show-toplevel 2>$null),

    [Parameter()]
    [string]$NUnitAnalyzersVersion = "4.11.2",

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

# --- Check git status ---
Write-Host "Checking git status..." -ForegroundColor Cyan
$gitStatus = git -C $RepoRoot status --porcelain
if ($gitStatus) {
    Write-Warning "Working tree is not clean. Uncommitted changes:"
    $gitStatus | ForEach-Object { Write-Warning "  $_" }
    Write-Warning "Proceeding anyway — the setup changes will be mixed with existing modifications."
}

# --- Paths ---
$packagesPropsPath = Join-Path $RepoRoot "eng" "Packages.Data.props"
$targetsPath = Join-Path $RepoRoot "eng" "Directory.Build.Common.targets"

if (-not (Test-Path $packagesPropsPath)) {
    Write-Error "Cannot find $packagesPropsPath"
    return
}
if (-not (Test-Path $targetsPath)) {
    Write-Error "Cannot find $targetsPath"
    return
}

# --- Update eng/Packages.Data.props ---
Write-Host "Updating $packagesPropsPath..." -ForegroundColor Cyan

$propsContent = Get-Content $packagesPropsPath -Raw

# 1a. Add NUnitAnalyzersVersion property if not already present
if ($propsContent -match "NUnitAnalyzersVersion") {
    Write-Host "  NUnitAnalyzersVersion property already exists, skipping." -ForegroundColor Yellow
} else {
    # Insert after the NUnitVersion property line
    $propsContent = $propsContent -replace '(<NUnitVersion>[^<]+</NUnitVersion>)', "`$1`n    <NUnitAnalyzersVersion>$NUnitAnalyzersVersion</NUnitAnalyzersVersion>"
    Write-Host "  Added NUnitAnalyzersVersion property ($NUnitAnalyzersVersion)." -ForegroundColor Green
}

# 1b. Add PackageReference for NUnit.Analyzers in the test ItemGroup if not already present
if ($propsContent -match 'PackageReference\s+Update="NUnit\.Analyzers"') {
    Write-Host "  NUnit.Analyzers PackageReference already exists in Packages.Data.props, skipping." -ForegroundColor Yellow
} else {
    # Insert after the NUnit3TestAdapter PackageReference line
    $propsContent = $propsContent -replace '(<PackageReference Update="NUnit3TestAdapter" Version="[^"]+"\s*/>)', "`$1`n    <PackageReference Update=""NUnit.Analyzers"" Version=""`$(NUnitAnalyzersVersion)"" />"
    Write-Host "  Added NUnit.Analyzers PackageReference to test ItemGroup." -ForegroundColor Green
}

Set-Content -Path $packagesPropsPath -Value $propsContent -NoNewline

# --- Update eng/Directory.Build.Common.targets ---
Write-Host "Updating $targetsPath..." -ForegroundColor Cyan

$targetsContent = Get-Content $targetsPath -Raw

# Add NUnit.Analyzers to the management plane test ItemGroup if not already present
if ($targetsContent -match 'PackageReference Include="NUnit\.Analyzers"') {
    Write-Host "  NUnit.Analyzers already present in Directory.Build.Common.targets, skipping." -ForegroundColor Yellow
} else {
    # Insert after <PackageReference Include="NUnit" /> in the mgmt test block
    # The mgmt test block has: <PackageReference Include="NUnit" /> followed by <PackageReference Include="NUnit3TestAdapter" />
    $targetsContent = $targetsContent -replace '(<PackageReference Include="NUnit" />\s*\n)(\s*<PackageReference Include="NUnit3TestAdapter" />)', "`$1    <PackageReference Include=""NUnit.Analyzers"" />`n`$2"
    Write-Host "  Added NUnit.Analyzers to management plane test ItemGroup." -ForegroundColor Green
}

Set-Content -Path $targetsPath -Value $targetsContent -NoNewline

# --- Commit ---
if (-not $SkipCommit) {
    Write-Host "Committing changes..." -ForegroundColor Cyan
    git -C $RepoRoot add $packagesPropsPath $targetsPath
    git -C $RepoRoot commit -m "Add NUnit.Analyzers for NUnit 4 migration"
    Write-Host "Committed setup changes." -ForegroundColor Green
} else {
    Write-Host "Skipping commit (-SkipCommit specified)." -ForegroundColor Yellow
}

Write-Host "`nSetup complete. You can now run run-migration.ps1." -ForegroundColor Cyan