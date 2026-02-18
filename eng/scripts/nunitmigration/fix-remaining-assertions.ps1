<#
.SYNOPSIS
    Fixes remaining classic NUnit Assert calls that dotnet format missed.
    Converts Assert.IsTrue/IsFalse/IsNull/IsNotNull/AreEqual/etc to Assert.That constraint model.

.PARAMETER ServiceDirectories
    Array of service directory names (e.g., "core", "template").

.PARAMETER RepoRoot
    Root of the azure-sdk-for-net repository. Defaults to git root.

.PARAMETER WhatIf
    Preview changes without modifying files.
#>
[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)]
    [string[]]$ServiceDirectories,

    [Parameter()]
    [string]$RepoRoot = (git rev-parse --show-toplevel 2>$null),

    [switch]$WhatIf
)

Set-StrictMode -Version Latest
$ErrorActionPreference = "Stop"

if (-not $RepoRoot) {
    Write-Error "Could not determine repo root."
    return
}
$RepoRoot = Resolve-Path $RepoRoot

# ---- Helper: Extract balanced parentheses content ----
function Get-BalancedParenContent {
    param([string]$Text, [int]$StartIndex)
    # StartIndex should point to the opening '('
    if ($Text[$StartIndex] -ne '(') { return $null }

    $depth = 0
    $inString = $false
    $stringChar = $null
    $escaped = $false

    for ($i = $StartIndex; $i -lt $Text.Length; $i++) {
        $ch = $Text[$i]

        if ($escaped) { $escaped = $false; continue }
        if ($ch -eq '\') { $escaped = $true; continue }

        if ($inString) {
            if ($ch -eq $stringChar) { $inString = $false }
            continue
        }

        if ($ch -eq '"' -or $ch -eq "'") {
            $inString = $true
            $stringChar = $ch
            continue
        }

        if ($ch -eq '(') { $depth++ }
        elseif ($ch -eq ')') {
            $depth--
            if ($depth -eq 0) {
                return @{
                    Content  = $Text.Substring($StartIndex + 1, $i - $StartIndex - 1)
                    EndIndex = $i
                }
            }
        }
    }
    return $null
}

# ---- Helper: Split arguments at top-level commas ----
function Split-TopLevelArgs {
    param([string]$ArgsText)

    $args_list = @()
    $depth = 0
    $inString = $false
    $stringChar = $null
    $escaped = $false
    $current = ""

    for ($i = 0; $i -lt $ArgsText.Length; $i++) {
        $ch = $ArgsText[$i]

        if ($escaped) { $escaped = $false; $current += $ch; continue }
        if ($ch -eq '\') { $escaped = $true; $current += $ch; continue }

        if ($inString) {
            $current += $ch
            if ($ch -eq $stringChar) { $inString = $false }
            continue
        }

        if ($ch -eq '"' -or $ch -eq "'") {
            $inString = $true
            $stringChar = $ch
            $current += $ch
            continue
        }

        if ($ch -eq '(' -or $ch -eq '[' -or $ch -eq '<') { $depth++ }
        elseif ($ch -eq ')' -or $ch -eq ']' -or $ch -eq '>') { $depth-- }

        if ($ch -eq ',' -and $depth -eq 0) {
            $args_list += $current.Trim()
            $current = ""
        } else {
            $current += $ch
        }
    }
    if ($current.Trim()) { $args_list += $current.Trim() }
    return $args_list
}

# ---- Define conversion rules ----
# Single-arg: XXX(expr) → Assert.That(expr, constraint)
# Single-arg-msg: XXX(expr, msg) → Assert.That(expr, constraint, msg)
# Two-arg: XXX(a, b) → Assert.That(a, constraint(b))  (or swap)
# Two-arg-msg: XXX(a, b, msg) → Assert.That(a, constraint(b), msg)  (or swap)

$assertConversions = @{
    'IsTrue'     = @{ Type = 'single'; Constraint = 'Is.True' }
    'True'       = @{ Type = 'single'; Constraint = 'Is.True' }
    'IsFalse'    = @{ Type = 'single'; Constraint = 'Is.False' }
    'False'      = @{ Type = 'single'; Constraint = 'Is.False' }
    'IsNull'     = @{ Type = 'single'; Constraint = 'Is.Null' }
    'Null'       = @{ Type = 'single'; Constraint = 'Is.Null' }
    'IsNotNull'  = @{ Type = 'single'; Constraint = 'Is.Not.Null' }
    'NotNull'    = @{ Type = 'single'; Constraint = 'Is.Not.Null' }
    'IsEmpty'    = @{ Type = 'single'; Constraint = 'Is.Empty' }
    'IsNotEmpty' = @{ Type = 'single'; Constraint = 'Is.Not.Empty' }
    'AreEqual'   = @{ Type = 'two-swap'; ConstraintFn = 'Is.EqualTo' }
    'AreNotEqual' = @{ Type = 'two-swap'; ConstraintFn = 'Is.Not.EqualTo' }
    'Greater'    = @{ Type = 'two'; ConstraintFn = 'Is.GreaterThan' }
    'Less'       = @{ Type = 'two'; ConstraintFn = 'Is.LessThan' }
    'GreaterOrEqual' = @{ Type = 'two'; ConstraintFn = 'Is.GreaterThanOrEqualTo' }
    'LessOrEqual'    = @{ Type = 'two'; ConstraintFn = 'Is.LessThanOrEqualTo' }
    'Contains'   = @{ Type = 'two-swap'; ConstraintFn = 'Does.Contain' }
    'AreSame'    = @{ Type = 'two-swap'; ConstraintFn = 'Is.SameAs' }
    'AreNotSame' = @{ Type = 'two-swap'; ConstraintFn = 'Is.Not.SameAs' }
    'IsInstanceOf' = @{ Type = 'single'; Constraint = 'Is.InstanceOf' }
}

# StringAssert methods: StringAssert.XXX(expected, actual) — args are (expected, actual)
$stringAssertConversions = @{
    'Contains'       = @{ Type = 'two-swap'; ConstraintFn = 'Does.Contain' }
    'DoesNotContain' = @{ Type = 'two-swap'; ConstraintFn = 'Does.Not.Contain' }
    'StartsWith'     = @{ Type = 'two-swap'; ConstraintFn = 'Does.StartWith' }
    'DoesNotStartWith' = @{ Type = 'two-swap'; ConstraintFn = 'Does.Not.StartWith' }
    'EndsWith'       = @{ Type = 'two-swap'; ConstraintFn = 'Does.EndWith' }
    'DoesNotEndWith' = @{ Type = 'two-swap'; ConstraintFn = 'Does.Not.EndWith' }
    'IsMatch'        = @{ Type = 'two-swap'; ConstraintFn = 'Does.Match' }
    'DoesNotMatch'   = @{ Type = 'two-swap'; ConstraintFn = 'Does.Not.Match' }
}

# CollectionAssert methods
$collectionAssertConversions = @{
    'AreEqual'           = @{ Type = 'two-swap'; ConstraintFn = 'Is.EqualTo' }
    'AreNotEqual'        = @{ Type = 'two-swap'; ConstraintFn = 'Is.Not.EqualTo' }
    'AreEquivalent'      = @{ Type = 'two-swap'; ConstraintFn = 'Is.EquivalentTo' }
    'AreNotEquivalent'   = @{ Type = 'two-swap'; ConstraintFn = 'Is.Not.EquivalentTo' }
    'Contains'           = @{ Type = 'two'; ConstraintFn = 'Does.Contain' }
    'DoesNotContain'     = @{ Type = 'two'; ConstraintFn = 'Does.Not.Contain' }
    'IsEmpty'            = @{ Type = 'single'; Constraint = 'Is.Empty' }
    'IsNotEmpty'         = @{ Type = 'single'; Constraint = 'Is.Not.Empty' }
    'AllItemsAreNotNull' = @{ Type = 'single'; Constraint = 'Has.None.Null' }
    'AllItemsAreUnique'  = @{ Type = 'single'; Constraint = 'Is.Unique' }
    'IsOrdered'          = @{ Type = 'single'; Constraint = 'Is.Ordered' }
    'IsSubsetOf'         = @{ Type = 'two'; ConstraintFn = 'Is.SubsetOf' }
    'IsSupersetOf'       = @{ Type = 'two'; ConstraintFn = 'Is.SupersetOf' }
}

# All prefix/conversion combos to process
$conversionSets = @(
    @{ Prefix = 'Assert'; Conversions = $assertConversions; Marker = 'SKIP_ASSERT_MARKER'; MarkerLen = 7 }
    @{ Prefix = 'StringAssert'; Conversions = $stringAssertConversions; Marker = 'SKIP_STRASSERT_MARKER'; MarkerLen = 13 }
    @{ Prefix = 'CollectionAssert'; Conversions = $collectionAssertConversions; Marker = 'SKIP_COLLASSERT_MARKER'; MarkerLen = 17 }
)

# ---- Conversion function ----
function ConvertAssertions {
    param(
        [string]$Content,
        [string]$Prefix,
        [hashtable]$Conversions,
        [string]$Marker,
        [int]$MarkerLen
    )

    $methodNames = ($Conversions.Keys | Sort-Object -Descending { $_.Length }) -join '|'
    $pattern = [regex]::Escape($Prefix) + "\.($methodNames)\("

    if ($Content -notmatch $pattern) {
        return @{ Content = $Content; Count = 0 }
    }

    $newContent = $Content
    $fixCount = 0
    $changed = $true
    $maxIter = 500
    $iter = 0

    while ($changed -and $iter -lt $maxIter) {
        $changed = $false
        $iter++

        $match = [regex]::Match($newContent, $pattern)
        if (-not $match.Success) { break }

        $methodName = $match.Groups[1].Value
        $assertStart = $match.Index
        $parenStart = $match.Index + $match.Length - 1

        $result = Get-BalancedParenContent -Text $newContent -StartIndex $parenStart
        if (-not $result) { break }

        $fullMatchEnd = $result.EndIndex
        $argsContent = $result.Content

        $conv = $Conversions[$methodName]
        $parsedArgs = @(Split-TopLevelArgs -ArgsText $argsContent)

        $replacement = $null

        switch ($conv.Type) {
            'single' {
                if ($parsedArgs.Count -eq 1) {
                    $replacement = "Assert.That($($parsedArgs[0]), $($conv.Constraint))"
                } elseif ($parsedArgs.Count -eq 2) {
                    $replacement = "Assert.That($($parsedArgs[0]), $($conv.Constraint), $($parsedArgs[1]))"
                }
            }
            'two' {
                if ($parsedArgs.Count -eq 2) {
                    $replacement = "Assert.That($($parsedArgs[0]), $($conv.ConstraintFn)($($parsedArgs[1])))"
                } elseif ($parsedArgs.Count -eq 3) {
                    $replacement = "Assert.That($($parsedArgs[0]), $($conv.ConstraintFn)($($parsedArgs[1])), $($parsedArgs[2]))"
                }
            }
            'two-swap' {
                if ($parsedArgs.Count -eq 2) {
                    $replacement = "Assert.That($($parsedArgs[1]), $($conv.ConstraintFn)($($parsedArgs[0])))"
                } elseif ($parsedArgs.Count -eq 3) {
                    $replacement = "Assert.That($($parsedArgs[1]), $($conv.ConstraintFn)($($parsedArgs[0])), $($parsedArgs[2]))"
                }
            }
        }

        if ($replacement) {
            $newContent = $newContent.Substring(0, $assertStart) + $replacement + $newContent.Substring($fullMatchEnd + 1)
            $fixCount++
            $changed = $true
        } else {
            $newContent = $newContent.Substring(0, $assertStart) + $Marker + $newContent.Substring($assertStart + $MarkerLen)
        }
    }

    $newContent = $newContent -replace [regex]::Escape($Marker), "$Prefix."
    return @{ Content = $newContent; Count = $fixCount }
}

# ---- Process files ----
$totalFixed = 0
$totalFiles = 0

foreach ($svcDir in $ServiceDirectories) {
    $sdkPath = Join-Path $RepoRoot "sdk\$svcDir"
    if (-not (Test-Path $sdkPath)) {
        Write-Warning "Directory not found: $sdkPath"
        continue
    }

    $csFiles = Get-ChildItem -Path $sdkPath -Recurse -Filter "*.cs" | Where-Object {
        $_.FullName -match '\\tests\\' -or $_.FullName -match '\\src\\.*Test'
    }

    foreach ($file in $csFiles) {
        $content = Get-Content $file.FullName -Raw
        if (-not $content) { continue }

        # Quick check: does file have any classic assert calls?
        if ($content -notmatch 'Assert\.|StringAssert\.|CollectionAssert\.') { continue }

        $newContent = $content
        $fileFixCount = 0

        # Pass 0: Simple rename of StringAssert.That( and CollectionAssert.That( to Assert.That(
        # These are already valid constraint-syntax calls with wrong class name
        $thatCount = 0
        $beforeLen = $newContent.Length
        $newContent = $newContent -replace 'StringAssert\.That\(', 'Assert.That('
        if ($newContent.Length -ne $beforeLen) {
            # Count approximate fixes by character length change
            $thatCount += [math]::Round(($beforeLen - $newContent.Length) / 6)  # "StringAssert" is 6 chars longer than "Assert"
        }
        $beforeLen = $newContent.Length
        $newContent = $newContent -replace 'CollectionAssert\.That\(', 'Assert.That('
        if ($newContent.Length -ne $beforeLen) {
            $thatCount += [math]::Round(($beforeLen - $newContent.Length) / 10)  # "CollectionAssert" is 10 chars longer than "Assert"
        }
        $fileFixCount += $thatCount

        # Pass 1-3: Convert old-style methods for each prefix
        foreach ($set in $conversionSets) {
            $result = ConvertAssertions -Content $newContent -Prefix $set.Prefix `
                -Conversions $set.Conversions -Marker $set.Marker -MarkerLen $set.MarkerLen
            $newContent = $result.Content
            $fileFixCount += $result.Count
        }

        if ($fileFixCount -gt 0) {
            $relativePath = $file.FullName -replace [regex]::Escape("$RepoRoot\"), ''
            if ($WhatIf) {
                Write-Host "  [WhatIf] Would fix $fileFixCount assertions in $relativePath" -ForegroundColor Yellow
            } else {
                Set-Content -Path $file.FullName -Value $newContent -NoNewline
                Write-Host "  Fixed $fileFixCount assertions in $relativePath" -ForegroundColor Green
            }
            $totalFixed += $fileFixCount
            $totalFiles++
        }
    }
}

Write-Host "`n=== Summary ===" -ForegroundColor Cyan
Write-Host "Total assertions fixed: $totalFixed across $totalFiles files" -ForegroundColor White
if ($WhatIf) {
    Write-Host "(WhatIf mode — no files were modified)" -ForegroundColor Yellow
}
