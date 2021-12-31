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
    Write-Host "���ڸ����ļ� $($file) �İ汾�ţ�$($version)"
    $xml = New-Object -TypeName XML
    $xml.Load($file)
    $xml.package.metadata.version = $version
    WriteXml $xml $file
    Write-Host "$($file)�汾�Ÿ���Ϊ$($version)"
}

function NugetPack()
{
    $file = "$($rootPath)\build\OSharp.Template.WebApi.nuspec"
    Write-Host "���ڽ��ļ� $($file) ����nuget���"
    & nuget pack $file

    $input = Read-Host "�Ƿ�װ��ģ�����Y/N"
    if($input -eq "Y")
    {
        & dotnet new -u "OSharp.Template.WebApi"
        & dotnet new -i "OSharp.Template.WebApi.$($version).nupkg"
    }
}

$now = [DateTime]::Now
$rootPath = ($ENV:WORKSPACE)
if($rootPath -eq $null)
{
    $rootPath = Split-Path -Parent $MyInvocation.MyCommand.Definition
    $rootPath = Split-Path -Parent $rootPath
}
Write-Host ("��ǰĿ¼��$($rootPath)")
$version = GetVersion
Write-Host ("��ǰ�汾��$($version)")
SetNuspecVersion
NugetPack