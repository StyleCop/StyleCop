REM **Required for building visual studio extensions, Point this to instaled version of sdk** 
set "ImportSDKPath=%VSSDK140Install% 

REM **Required to build Wix Projects,when wix is not installed on dev machine**
set WixCATargetsPath=%WixToolsDirectory%\sdk\wix.ca.targets
set WixTasksPath=%WixToolsDirectory%\WixTasks.dll
set WixSDKPath=%WixToolsDirectory%\sdk\

REM **Required to use vstest instead of mstest**
set VSTESTSCRIPT=%STTOOLS%\VsTest\RunAllTests.proj
