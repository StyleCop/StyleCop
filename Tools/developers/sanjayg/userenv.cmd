REM **Required for building visual studio extensions, Point this to instaled version of sdk** 
set "ImportSDKPath=%PROGRAMFILES(X86)%\MSBuild\Microsoft\VisualStudio\v14.0\VSSDK\" 

REM **Required to build Wix Projects,when wix is not installed on dev machine**
set WixCATargetsPath=%WixToolsDirectory%\sdk\wix.ca.targets
set WixTasksPath=%WixToolsDirectory%\WixTasks.dll
set WixSDKPath=%WixToolsDirectory%\sdk\

REM **Required to use vstest instead of mstest**
set VSTESTSCRIPT=%STTOOLS%\VsTest\RunAllTests.proj

REM **Required to detect correct resharper version
IF EXIST "%LOCALAPPDATA%\JetBrains\Installations\ReSharperPlatformVs14\JetBrains.Annotations.dll" (
	echo JetBrains ReSharper 9.2 was found...
	SET "ReSharperFound=1"
   )
