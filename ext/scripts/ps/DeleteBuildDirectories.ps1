$folders = "bin", "build"

foreach ($folder in $folders)
{
    if (Test-Path $folder)
    {
        Remove-Item $folder -Recurse -Force
        Write-Host "Folder ""$folder"" deleted."
    }
    else
    {
        Write-Host "Folder ""$folder"" dosn't exists."
    }
}
