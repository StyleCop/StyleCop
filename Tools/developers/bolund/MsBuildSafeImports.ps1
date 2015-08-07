		
function add-safeimports
{	
	$keyName =  "StyleCopShipping" + $env:SDCLIENT
  $targetsName = $env:SDROOT + "\tools\msbuild\Microsoft.SourceAnalysis.Shipping.Targets"
  
	$wowSubkey = ""	
	if ($env:IsWow64 -ieq "1")
	{
		$wowSubkey = "\Wow6432Node"
	}
	
	$keyPath = [Microsoft.Win32.Registry]::LocalMachine
	$keyPath = "$keyPath" + "\Software"
	$keyPath = "$keyPath" + "$wowSubkey"
	$keyPath = "$keyPath" + "\Microsoft\VisualStudio\9.0\MSBuild\SafeImports"
	
	[Microsoft.Win32.Registry]::SetValue($keyPath, $keyName, $targetsName);	
}