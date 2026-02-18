$file = "c:\Users\mredding\source\repos\azure-sdk-for-net\eng\scripts\nunitmigration\migration-guide.md"
$lines = [System.IO.File]::ReadAllLines($file)

$newLines = [System.Collections.Generic.List[string]]::new()
$inBlock = $false
$services = [System.Collections.Generic.List[string]]::new()
$convertedBlocks = 0

for ($i = 0; $i -lt $lines.Count; $i++) {
    $line = $lines[$i]

    if (-not $inBlock -and $line.Trim() -eq '```powershell') {
        # Peek ahead to see if next line is a Migrate-NUnit4 line
        if (($i + 1) -lt $lines.Count -and $lines[$i + 1] -match 'Migrate-NUnit4\.ps1') {
            $inBlock = $true
            $services.Clear()
            $newLines.Add($line)
            continue
        }
    }

    if ($inBlock) {
        if ($line -match 'Migrate-NUnit4\.ps1 -ServiceDirectory (\S+)') {
            $services.Add($Matches[1])
            continue
        }

        if ($line.Trim() -eq '```') {
            if ($services.Count -gt 0) {
                $svcList = $services -join ", "
                $newLines.Add(".\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories $svcList")
                $convertedBlocks++
            }
            $newLines.Add($line)
            $inBlock = $false
            continue
        }

        # Some other line in the block
        $newLines.Add($line)
        continue
    }

    $newLines.Add($line)
}

[System.IO.File]::WriteAllLines($file, $newLines.ToArray())
Write-Host "Converted $convertedBlocks code blocks."
Write-Host "Total lines: before=$($lines.Count) after=$($newLines.Count)"

# Verify
$remaining = (Select-String -Path $file -Pattern "Migrate-NUnit4" | Measure-Object).Count
Write-Host "Remaining Migrate-NUnit4 references: $remaining"
