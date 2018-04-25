cls
Set-Alias -Name msbuild -Value "C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\bin\msbuild.exe"
msbuild $PSScriptRoot\Albatross.Database.csproj -property:Configuration=Release
nuget pack $PSScriptRoot\Albatross.Database.nuspec -outputDirectory C:\Workspace\packages
