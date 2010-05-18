@echo off
setlocal

IF "%1"=="" GOTO Usage

set BUILDNUMBER=%1
set CODESIGN=\\NAVBR293\Codesign\jasonall
set CODESIGNDROP=%CODESIGN%\%BUILDNUMBER%
set BUILDDROP=%PROJECTROOT%\BuildDrop\Release
set INSTALLDROP=%PROJECTROOT%\InstallDrop\Release
set MSILOCATION=%INSTALLDROP%\Microsoft.StyleCop.msi

echo --------------------------------------------------------------
echo Running build and tests
call verifybuild retail -SkipWixBuild

echo --------------------------------------------------------------
echo Current content of BuildDrop folder:
dir /s /b /A:-D %BUILDDROP%

echo --------------------------------------------------------------
echo Moving binaries to unsigned drop location
if EXIST "%BUILDDROP%\unsigned" rd /s /q "%BUILDDROP%\unsigned"
md %BUILDDROP%\unsigned"
move "%BUILDDROP%\*.exe" "%BUILDDROP%\unsigned"
move "%BUILDDROP%\*.dll" "%BUILDDROP%\unsigned"

echo --------------------------------------------------------------
echo Copying binaries to Code Sign location
if EXIST "%CODESIGNDROP%" rd /s /q "%CODESIGNDROP%"
md "%CODESIGNDROP%"

start %CODESIGN%

xcopy /e /d /y "%BUILDDROP%\unsigned\*.exe" "%CODESIGNDROP%"
xcopy /e /d /y "%BUILDDROP%\unsigned\*.dll" "%CODESIGNDROP%"

REM Create a file called 'stylecop' at the codesign drop location to kick off the codesign process
echo start > "%CODESIGNDROP%\stylecop"

echo --------------------------------------------------------------
echo Waiting for signed binaries
:WAITFORSIGNEDBINARIES
call %PROJECTROOT%\tools\scripts\sleep.vbs
if NOT EXIST "%CODESIGNDROP%_Codesigned\CodesignComplete" goto WAITFORSIGNEDBINARIES

echo --------------------------------------------------------------
echo Copying signed binaries to signed build drop location
xcopy /e /d /y "%CODESIGNDROP%_Codesigned\*.*" "%BUILDDROP%"

if EXIST "%BUILDDROP%\CodesignComplete" goto BUILDMSI
echo --------------------------------------------------------------
echo Code Sign Failed. The CodesignComplete flag does not exist in the BuildDrop folder.
goto END

:BUILDMSI
echo --------------------------------------------------------------
echo Building setup MSI
call verifybuild retail -WixBuildOnly

if EXIST "%MSILOCATION%" goto SIGNMSI
echo --------------------------------------------------------------
echo MSI Build failed
goto END

:SIGNMSI
echo --------------------------------------------------------------
echo Moving MSI to unsigned drop location
if EXIST "%INSTALLDROP%\unsigned" rd /s /q "%INSTALLDROP%\unsigned"
md %INSTALLDROP%\unsigned"
move "%INSTALLDROP%\*.msi" "%INSTALLDROP%\unsigned"

echo --------------------------------------------------------------
echo Copying MSI to Code Sign location
if EXIST "%CODESIGNDROP%_MSI" rd /s /q "%CODESIGNDROP%_MSI"
md "%CODESIGNDROP%_MSI"

xcopy /e /d /y "%INSTALLDROP%\unsigned\*.msi" "%CODESIGNDROP%_MSI"

REM Create a file called 'stylecop' at the codesign drop location to kick off the codesign process
echo start > "%CODESIGNDROP%_MSI\stylecop"

echo --------------------------------------------------------------
echo Waiting for signed MSI
:WAITFORSIGNEDMSI
call %PROJECTROOT%\tools\scripts\sleep.vbs
if NOT EXIST "%CODESIGNDROP%_MSI_Codesigned\CodesignComplete" goto WAITFORSIGNEDMSI

echo --------------------------------------------------------------
echo Copying signed MSI to signed install drop location
xcopy /e /d /y "%CODESIGNDROP%_MSI_Codesigned\*.*" "%INSTALLDROP%"

if EXIST "%INSTALLDROP%\CodesignComplete" goto CLEANUP
echo --------------------------------------------------------------
echo Code Sign of MSI Failed. The CodesignComplete flag does not exist in the InstallDrop folder.
goto END

:CLEANUP
echo --------------------------------------------------------------
echo Cleaning up files from signing server
rd /s /q "%CODESIGNDROP%"
rd /s /q "%CODESIGNDROP%_Codesigned"
rd /s /q "%CODESIGNDROP%_MSI"
rd /s /q "%CODESIGNDROP%_MSI_Codesigned"

:DONE
goto END

:Usage
Echo.
ECHO Usage:
Echo OfficialBuild.cmd UniqueBuildNumber

:END
endlocal