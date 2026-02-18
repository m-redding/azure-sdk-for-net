param()
$file = "c:\Users\mredding\source\repos\azure-sdk-for-net\eng\scripts\nunitmigration\migration-guide.md"
$encoding = [System.Text.Encoding]::UTF8
$lines = [System.IO.File]::ReadAllLines($file, $encoding)

Write-Host "Read $($lines.Count) lines"
Write-Host "Sample line 194: $($lines[193])"

$output = [System.Collections.Generic.List[string]]::new()
$collecting = $false
$svcs = [System.Collections.Generic.List[string]]::new()
$converted = 0

for ($i = 0; $i -lt $lines.Count; $i++) {
    $ln = $lines[$i]

    if ($collecting) {
        if ($ln -match '\\eng\\scripts\\Migrate-NUnit4\.ps1 -ServiceDirectory (\S+)') {
            $svcs.Add($Matches[1])
        }
        elseif ($ln.Trim() -eq '```') {
            # End of block
            $joined = $svcs -join ", "
            $output.Add(".\eng\scripts\nunitmigration\run-migration.ps1 -ServiceDirectories $joined")
            $output.Add($ln)
            $collecting = $false
            $converted++
        }
        else {
            $output.Add($ln)
        }
        continue
    }

    # Check if this starts a Migrate-NUnit4 block
    if ($ln.Trim() -eq '```powershell' -and ($i + 1) -lt $lines.Count -and $lines[$i + 1] -match '\\eng\\scripts\\Migrate-NUnit4\.ps1') {
        $output.Add($ln)
        $collecting = $true
        $svcs = [System.Collections.Generic.List[string]]::new()
        continue
    }

    $output.Add($ln)
}

Write-Host "Output: $($output.Count) lines, converted $converted blocks"

# Write with UTF8 no BOM
$utf8NoBom = [System.Text.UTF8Encoding]::new($false)
[System.IO.File]::WriteAllLines($file, $output.ToArray(), $utf8NoBom)

# Verify
$check = [System.IO.File]::ReadAllLines($file, $encoding)
Write-Host "Verify: $($check.Count) lines"
$remains = ($check | Where-Object { $_ -match 'Migrate-NUnit4' }).Count
Write-Host "Remaining Migrate-NUnit4 lines: $remains"
