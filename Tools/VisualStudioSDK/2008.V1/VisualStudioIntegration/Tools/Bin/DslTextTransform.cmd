@echo off
:: Call TextTransform.exe with common options required by a standard DSL Tools project

:: Work out whether we are on 64-bit or not
set x64RegKey=Wow6432Node\& set CommonFilesDir=%CommonProgramFiles(x86)%
if "%PROCESSOR_ARCHITECTURE%"=="x86" set x64RegKey=& set CommonFilesDir=%CommonProgramFiles%

:: Obtain DSL Tools  include template and assembly locations from the registry.
for /F "tokens=2,*" %%I in ('reg query HKEY_LOCAL_MACHINE\SOFTWARE\%x64RegKey%Microsoft\VisualStudio\9.0\TextTemplating\IncludeFolders\.tt /v Include0') do (
	set DSLTOOLSINCLUDE3=%%J
)
for /F "tokens=2,*" %%I in ('reg query HKEY_LOCAL_MACHINE\SOFTWARE\%x64RegKey%Microsoft\VisualStudio\DSLTools\2.1 /v AssemblyDir') do (
	set DSLTOOLSASSEMBLYDIR=%%J
)

:: Strip trailing slashes from the paths
if "%DSLTOOLSINCLUDE3:~-1%"=="\" set DSLTOOLSINCLUDE3=%DSLTOOLSINCLUDE3:~0,-1%
if "%DSLTOOLSASSEMBLYDIR:~-1%"=="\" set DSLTOOLSASSEMBLYDIR=%DSLTOOLSASSEMBLYDIR:~0,-1%

set TT=%CommonFilesDir%\Microsoft Shared\TextTemplating\1.2

if not exist "%TT%\TextTransform.exe" (
	echo DSL Tools are not installed or installed incorrectly on this machine.
	goto :EOF
)

if not exist %1 goto :usage

"%TT%\TextTransform.exe" -I "%DSLTOOLSINCLUDE3%" -r Microsoft.VisualStudio.TextTemplating.VSHost.dll -P "%DSLTOOLSASSEMBLYDIR%" -dp "DslDirectiveProcessor!Microsoft.VisualStudio.Modeling.DslDefinition.DslDirectiveProcessor!Microsoft.VisualStudio.Modeling.Sdk.DslDefinition, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" %1 %2 %3 %4 %5 %6 %7 %8 %9
goto :EOF

:usage
echo DslTextTransform - Call TextTransform.exe with common options required by a standard DSL Tools project
echo Usage:
echo   DslTextTransform Template_To_Transform

:EOF



