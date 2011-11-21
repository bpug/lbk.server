param($installPath, $toolsPath, $package, $project)

$source = "$toolsPath\*.*"
$destination = "$installPath\..\..\..\lib\msbuild\"
$exclude = @("*.ps1")

if (Test-Path $destination)
{
    Remove-Item $destination -Recurse -Force
}

New-Item $destination -ItemType directory -Force

Copy-Item $source $destination -Exclude $exclude