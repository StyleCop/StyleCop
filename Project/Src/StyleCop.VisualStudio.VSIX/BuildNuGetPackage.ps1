param (
    [string]$nuspecPath,
    [string]$outputDirectory,
    [string]$buildConfiguration,
    [string]$nugetExePath
)

$assembly = [Reflection.Assembly]::LoadFrom($outputDirectory + "StyleCop.dll")
$customAttributes = [Reflection.CustomAttributeData]::GetCustomAttributes($assembly)

foreach ($customAttribute in $customAttributes)
{
    if ($customAttribute.AttributeType -Eq [System.Reflection.AssemblyInformationalVersionAttribute])
    {
       $informationalVersion = $customAttribute.ConstructorArguments[0].Value

       $properties = "-Properties Configuration=$buildConfiguration"

       & "$nugetExePath" pack "$nuspecPath" -Tool -BasePath "$outputDirectory " -OutputDirectory "$outputDirectory " -Properties Configuration=$buildConfiguration -Version $informationalVersion

       break;
    }
}