[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)]
    [string[]]$ServiceDirectories,

    [Parameter()]
    [string]$RepoRoot = (git rev-parse --show-toplevel 2>$null)
)

Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

if (-not $RepoRoot) {
    Write-Error "Could not determine repo root. Run this script from within the azure-sdk-for-net git repository."
    return
}

$RepoRoot = Resolve-Path $RepoRoot

# NUnit2xxx diagnostic IDs that have code fixers for classic assert -> constraint model conversion
$DiagnosticIds = @(
    "NUnit2001", "NUnit2002", "NUnit2003", "NUnit2004", "NUnit2005", "NUnit2006", "NUnit2007",
    "NUnit2010",
    "NUnit2015", "NUnit2016", "NUnit2017", "NUnit2018", "NUnit2019",
    "NUnit2021", "NUnit2023", "NUnit2024", "NUnit2025",
    "NUnit2027", "NUnit2028", "NUnit2029", "NUnit2030", "NUnit2031", "NUnit2032", "NUnit2033",
    "NUnit2034", "NUnit2035", "NUnit2036", "NUnit2037", "NUnit2038", "NUnit2039",
    "NUnit2048", "NUnit2049", "NUnit2050"
)
$diagnosticArg = $DiagnosticIds -join " "

$analyzerSnippet = '    <PackageReference Include="NUnit.Analyzers" />'

# Collect all test projects and track which csproj files we modify
$allTestProjects = @()
$modifiedCsprojs = @()

foreach ($serviceDir in $ServiceDirectories) {
    $sdkPath = Join-Path $RepoRoot "sdk" $serviceDir
    if (-not (Test-Path $sdkPath)) {
        Write-Warning "Service directory not found: $sdkPath — skipping."
        continue
    }

    Write-Host "`n=== Discovering test projects in sdk/$serviceDir ===" -ForegroundColor Cyan

    # Find test projects — they end with Tests.csproj (case-insensitive)
    $testProjects = Get-ChildItem -Path $sdkPath -Recurse -Filter "*.csproj" |
        Where-Object { $_.Name -match '[Tt]ests\.csproj$' }

    if (-not $testProjects) {
        Write-Host "  No test projects found in sdk/$serviceDir" -ForegroundColor Yellow
        continue
    }

    foreach ($proj in $testProjects) {
        Write-Host "  Found: $($proj.FullName -replace [regex]::Escape($RepoRoot), '')" -ForegroundColor DarkGray
        $allTestProjects += $proj

        # Check if this is a data plane test project (has explicit NUnit reference)
        $content = Get-Content $proj.FullName -Raw
        if ($content -match '<PackageReference Include="NUnit"') {
            # It has an explicit NUnit reference — check if NUnit.Analyzers is already there
            if ($content -notmatch '<PackageReference Include="NUnit\.Analyzers"') {
                # Add NUnit.Analyzers after the NUnit reference
                $newContent = $content -replace '(<PackageReference Include="NUnit"\s*/>)', "`$1`n$analyzerSnippet"
                Set-Content -Path $proj.FullName -Value $newContent -NoNewline
                $modifiedCsprojs += $proj.FullName
                Write-Host "    Added NUnit.Analyzers reference (data plane project)" -ForegroundColor Green
            } else {
                Write-Host "    NUnit.Analyzers already referenced" -ForegroundColor DarkGray
            }
        } else {
            Write-Host "    Management plane project (NUnit.Analyzers injected via targets)" -ForegroundColor DarkGray
        }
    }
}

if (-not $allTestProjects) {
    Write-Warning "No test projects found across all specified service directories."
    return
}

# --- Restore and run dotnet format for each test project ---
Write-Host "`n=== Running dotnet format analyzers ===" -ForegroundColor Cyan

$totalProjects = $allTestProjects.Count
$current = 0
$failed = @()

foreach ($proj in $allTestProjects) {
    $current++
    $relativePath = $proj.FullName -replace [regex]::Escape("$RepoRoot\"), ''
    Write-Host "`n[$current/$totalProjects] Processing: $relativePath" -ForegroundColor White

    # Restore first
    Write-Host "  Restoring..." -ForegroundColor DarkGray
    $restoreResult = dotnet restore $proj.FullName 2>&1
    if ($LASTEXITCODE -ne 0) {
        Write-Warning "  Restore failed for $relativePath — skipping dotnet format."
        $failed += @{ Project = $relativePath; Phase = "restore"; Output = ($restoreResult -join "`n") }
        continue
    }

    # Run dotnet format analyzers
    Write-Host "  Running dotnet format analyzers..." -ForegroundColor DarkGray
    $formatResult = dotnet format analyzers $proj.FullName --diagnostics $DiagnosticIds --severity info --no-restore 2>&1
    if ($LASTEXITCODE -ne 0) {
        Write-Warning "  dotnet format failed for $relativePath"
        $failed += @{ Project = $relativePath; Phase = "format"; Output = ($formatResult -join "`n") }
    } else {
        Write-Host "  Done." -ForegroundColor Green
    }
}

# --- Revert all .csproj changes ---
Write-Host "`n=== Reverting .csproj changes ===" -ForegroundColor Cyan

if ($modifiedCsprojs.Count -gt 0) {
    foreach ($csproj in $modifiedCsprojs) {
        $relativeCsproj = $csproj -replace [regex]::Escape("$RepoRoot\"), ''
        # Use git checkout to revert to the version before our modifications.
        # This avoids whitespace-only diffs in csproj files.
        git -C $RepoRoot checkout HEAD -- $relativeCsproj 2>$null
        if ($LASTEXITCODE -ne 0) {
            # If HEAD checkout fails (e.g., file is new), try the index
            git -C $RepoRoot checkout -- $relativeCsproj 2>$null
        }
        Write-Host "  Reverted: $relativeCsproj" -ForegroundColor DarkGray
    }
} else {
    Write-Host "  No .csproj files were modified." -ForegroundColor DarkGray
}

# --- Summary ---
Write-Host "`n=== Migration Summary ===" -ForegroundColor Cyan
Write-Host "  Services:       $($ServiceDirectories -join ', ')" -ForegroundColor White
Write-Host "  Test projects:  $totalProjects" -ForegroundColor White
Write-Host "  Succeeded:      $($totalProjects - $failed.Count)" -ForegroundColor Green
if ($failed.Count -gt 0) {
    Write-Host "  Failed:         $($failed.Count)" -ForegroundColor Red
    Write-Host "`nFailed projects:" -ForegroundColor Red
    foreach ($f in $failed) {
        Write-Host "  [$($f.Phase)] $($f.Project)" -ForegroundColor Red
    }
}

Write-Host "`nMigration code changes complete. Next steps:" -ForegroundColor Cyan
Write-Host "  1. Review changes:  git diff" -ForegroundColor White
Write-Host "  2. Commit:          git add sdk/ && git commit -m 'Migrate assertions to NUnit 4 constraint model'" -ForegroundColor White
Write-Host "  3. Run:             .\eng\scripts\nunitmigration\post-migration.ps1 -ServiceDirectories $($ServiceDirectories -join ', ')" -ForegroundColor White

