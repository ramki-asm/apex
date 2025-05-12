Add-Type -AssemblyName System.Windows.Forms

$resxPath = "..\Resources\Strings.resx"  # Path to English RESX
$outputPath = "..\Resources\Strings.zh-CN.resx"  # Output Chinese RESX

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