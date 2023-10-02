#nuget pack OSharp.Template.WebApi.nuspec

function WriteXml([System.Xml.XmlDocument]$xml, [string]$file)
{
    $encoding = New-Object System.Text.UTF8Encoding($true)
    $writer = New-Object System.IO.StreamWriter($file, $false, $encoding)
    $xml.Save($writer)
    $writer.Close()
}

function GetVersion()
{
    $file = "$($rootPath)\build\version.props"
    $xml = New-Object -TypeName XML
    $xml.Load($file)
    $version = $xml.Project.PropertyGroup.Version
    if($version.contains("VersionSuffixVersion"))
    {
        $version = "{0}.{1}{2}{3}" -f $xml.Project.PropertyGroup.VersionMain,$xml.Project.PropertyGroup.VersionPrefix,$xml.Project.PropertyGroup.VersionSuffix,$xml.Project.PropertyGroup.VersionSuffixVersion
    }
    else
    {
        $version = "{0}.{1}" -f $xml.Project.PropertyGroup.VersionMain,$xml.Project.PropertyGroup.VersionPrefix
    }
    return $version
}

function SetNuspecVersion()
{
    $file = "$($rootPath)\build\OSharp.Template.WebApi.nuspec"
    Write-Host "正在更新文件 $($file) 的版本号：$($version)"
    $xml = New-Object -TypeName XML
    $xml.Load($file)
    $xml.package.metadata.version = $version
    WriteXml $xml $file
    Write-Host "$($file)版本号更新为$($version)"
}

function NugetPack()
{
    $file = "$($rootPath)\build\OSharp.Template.WebApi.nuspec"
    Write-Host "正在将文件 $($file) 进行nuget打包"
    & nuget pack $file

    $input = "Y"#Read-Host "是否安装此模板包？Y/N"
    if($input -eq "Y")
    {
        & dotnet new uninstall "OSharp.Template.WebApi"
        & dotnet new install "OSharp.Template.WebApi.$($version).nupkg"
    }
}

$now = [DateTime]::Now
$rootPath = ($ENV:WORKSPACE)
if($rootPath -eq $null)
{
    $rootPath = Split-Path -Parent $MyInvocation.MyCommand.Definition
    $rootPath = Split-Path -Parent $rootPath
}
Write-Host ("当前目录：$($rootPath)")
$version = GetVersion
Write-Host ("当前版本：$($version)")
SetNuspecVersion
NugetPack