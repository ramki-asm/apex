Add-Type -AssemblyName System.Windows.Forms

# Adjust these paths if your RESX files are in another folder
$resxPath = "Resources\Strings.resx"
$outputPath = "Resources\Strings.zh-CN.resx"

[xml]$resx = Get-Content $resxPath
foreach($data in $resx.root.data) {
    $translated = [System.Windows.Forms.MessageBox]::Show(
        "Translate '$($data.value)' to Chinese", 
        "Manual Translation", 
        "OKCancel"
    )
    if ($translated -eq "OK") {
        $data.value = Read-Host "Enter Chinese translation"
    }
}
$resx.Save($outputPath)