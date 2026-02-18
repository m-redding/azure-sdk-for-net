#Requires -Version 7.0
<#
.SYNOPSIS
    Builds all solutions in the given service directories and reports errors organized by project.

.DESCRIPTION
    For each service directory, finds all .sln files and runs dotnet build.
    Build output is parsed for errors and organized by project for easy triage.

.PARAMETER ServiceDirectories
    One or more service directory names (e.g., "core", "storage", "keyvault").

.PARAMETER RepoRoot
    Root of the azure-sdk-for-net repository. Defaults to git repo root.

.EXAMPLE
    .\test-run-builds.ps1 -ServiceDirectories core, template
#>
[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)]
    [string[]]$ServiceDirectories,

    [Parameter()]
    [string]$RepoRoot = (git rev-parse --show-toplevel 2>$null)
)

Set-StrictMode -Version Latest
$ErrorActionPreference = "Continue"

if (-not $RepoRoot) {
    Write-Error "Could not determine repo root. Run this script from within the azure-sdk-for-net git repository."
    return
}

$RepoRoot = Resolve-Path $RepoRoot

# Collect results
$buildResults = @()

foreach ($serviceDir in $ServiceDirectories) {
    $sdkPath = Join-Path $RepoRoot "sdk" $serviceDir
    if (-not (Test-Path $sdkPath)) {
        Write-Warning "Service directory not found: $sdkPath — skipping."
        continue
    }

    Write-Host "`n=== Building solutions in sdk/$serviceDir ===" -ForegroundColor Cyan

    # Find all .sln files
    $solutions = Get-ChildItem -Path $sdkPath -Recurse -Filter "*.sln"

    if (-not $solutions) {
        Write-Host "  No .sln files found in sdk/$serviceDir" -ForegroundColor Yellow
        continue
    }

    foreach ($sln in $solutions) {
        $relativeSln = $sln.FullName -replace [regex]::Escape("$RepoRoot\"), ''
        Write-Host "`n  Building: $relativeSln" -ForegroundColor White

        # Run dotnet build and capture all output
        $buildOutput = dotnet build $sln.FullName --no-restore 2>&1 | Out-String
        $exitCode = $LASTEXITCODE

        # Also try with restore if no-restore failed
        if ($exitCode -ne 0 -and $buildOutput -match "Run a NuGet package restore") {
            Write-Host "    Retrying with restore..." -ForegroundColor Yellow
            $buildOutput = dotnet build $sln.FullName 2>&1 | Out-String
            $exitCode = $LASTEXITCODE
        }

        # Parse errors from build output
        # MSBuild error format: path(line,col): error CODE: message [project]
        $errorLines = $buildOutput -split "`n" | Where-Object { $_ -match '\s*:\s+error\s+\w+' }

        # Organize errors by project
        $errorsByProject = @{}
        foreach ($line in $errorLines) {
            $trimmed = $line.Trim()
            # Extract project name from [project] at end of line
            if ($trimmed -match '\[([^\]]+)\]$') {
                $projectFile = $Matches[1]
                $projectName = [System.IO.Path]::GetFileNameWithoutExtension($projectFile)
            } else {
                $projectName = "(unknown)"
            }

            if (-not $errorsByProject.ContainsKey($projectName)) {
                $errorsByProject[$projectName] = @()
            }
            $errorsByProject[$projectName] += $trimmed
        }

        $result = @{
            Solution    = $relativeSln
            Service     = $serviceDir
            ExitCode    = $exitCode
            ErrorCount  = $errorLines.Count
            Errors      = $errorsByProject
        }
        $buildResults += $result

        if ($exitCode -eq 0) {
            Write-Host "    ✅ Build succeeded" -ForegroundColor Green
        } else {
            Write-Host "    ❌ Build failed ($($errorLines.Count) errors)" -ForegroundColor Red
        }
    }
}

# --- Summary ---
Write-Host "`n" -NoNewline
Write-Host "=" * 60 -ForegroundColor Cyan
Write-Host "  BUILD SUMMARY" -ForegroundColor Cyan
Write-Host "=" * 60 -ForegroundColor Cyan

$successCount = ($buildResults | Where-Object { $_.ExitCode -eq 0 }).Count
$failCount = ($buildResults | Where-Object { $_.ExitCode -ne 0 }).Count

Write-Host "`n  Solutions built:  $($buildResults.Count)" -ForegroundColor White
Write-Host "  Succeeded:        $successCount" -ForegroundColor Green
Write-Host "  Failed:           $failCount" -ForegroundColor $(if ($failCount -gt 0) { "Red" } else { "Green" })

# Show detailed errors for failed builds
$failedResults = $buildResults | Where-Object { $_.ExitCode -ne 0 }

if ($failedResults) {
    Write-Host "`n" -NoNewline
    Write-Host "=" * 60 -ForegroundColor Red
    Write-Host "  BUILD ERRORS (by project)" -ForegroundColor Red
    Write-Host "=" * 60 -ForegroundColor Red

    foreach ($result in $failedResults) {
        Write-Host "`n  Solution: $($result.Solution)" -ForegroundColor Yellow

        if ($result.Errors.Count -eq 0) {
            Write-Host "    (no parseable error lines — check build output manually)" -ForegroundColor DarkGray
            continue
        }

        foreach ($projectName in ($result.Errors.Keys | Sort-Object)) {
            $projectErrors = $result.Errors[$projectName]
            Write-Host "`n    Project: $projectName ($($projectErrors.Count) errors)" -ForegroundColor Red

            # Deduplicate and show unique errors
            $uniqueErrors = $projectErrors | Select-Object -Unique
            foreach ($err in $uniqueErrors) {
                Write-Host "      $err" -ForegroundColor DarkRed
            }
        }
    }
}

# Return exit code
if ($failCount -gt 0) {
    Write-Host "`n❌ $failCount solution(s) failed to build." -ForegroundColor Red
    exit 1
} else {
    Write-Host "`n✅ All solutions built successfully." -ForegroundColor Green
    exit 0
}