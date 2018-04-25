cls
Set-Alias -Name msbuild -Value "C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\bin\msbuild.exe"
msbuild $PSScriptRoot\Albatross.Database.Ioc.SimpleInjector.csproj -property:Configuration=Release
nuget pack $PSScriptRoot\Albatross.Database.Ioc.SimpleInjector.nuspec -outputDirectory C:\Workspace\packages
