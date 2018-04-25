#build and pack
Set-Alias -Name msbuild -Value "C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\bin\msbuild.exe"

msbuild $PSScriptRoot\src\Albatross.Database\Albatross.Database.csproj -property:Configuration=Release
nuget pack $PSScriptRoot\src\Albatross.Database\Albatross.Database.nuspec -outputDirectory C:\Workspace\packages


msbuild $PSScriptRoot\src\Albatross.Database.SqlServer\Albatross.Database.SqlServer.csproj -property:Configuration=Release
nuget pack $PSScriptRoot\src\Albatross.Database.SqlServer\Albatross.Database.SqlServer.nuspec -outputDirectory C:\Workspace\packages


msbuild $PSScriptRoot\src\Albatross.Database.SqlServer.SimpleInjector\Albatross.Database.SqlServer.SimpleInjector.csproj -property:Configuration=Release
nuget pack $PSScriptRoot\src\Albatross.Database.SqlServer.SimpleInjector\Albatross.Database.SqlServer.SimpleInjector.nuspec -outputDirectory C:\Workspace\packages
