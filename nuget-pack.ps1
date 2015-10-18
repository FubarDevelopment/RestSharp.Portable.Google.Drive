[OutputType([void])]
param(
	[Parameter()]
	$config = "Release"
)

Remove-Item *.nupkg

$nuspecFiles = get-childitem RestSharp.Portable*\*.nuspec
ForEach ($nuspecFile in $nuspecFiles)
{
	$csFile = [System.IO.Path]::ChangeExtension($nuspecFile, ".csproj")
	& nuget pack "$csFile" -Properties "Configuration=$config" -IncludeReferencedProjects
}
