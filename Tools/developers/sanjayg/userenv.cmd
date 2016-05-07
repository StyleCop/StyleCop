REM **Required for building visual studio extensions, Point this to instaled version of sdk** 
set "ImportSDKPath=%PROGRAMFILES(X86)%\MSBuild\Microsoft\VisualStudio\v14.0\VSSDK\" 

REM **Required to build Wix Projects,when wix is not installed on dev machine**
set WixCATargetsPath=%WixToolsDirectory%\sdk\wix.ca.targets
set WixTasksPath=%WixToolsDirectory%\WixTasks.dll
set WixSDKPath=%WixToolsDirectory%\sdk\

REM **Required to use vstest instead of mstest**
set VSTESTSCRIPT=%~dp0..\..\VsTest\RunAllTests.proj

