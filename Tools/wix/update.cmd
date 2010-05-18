@echo off

setlocal

if "%1"=="" goto syntax
if "%1"=="/?" goto syntax
if "%1"=="-?" goto syntax

set wixbuild=%1

set wixdir=\\delivery\releases\wix\2.0.%wixbuild%
set tempdir=%temp%\wixupdate

if not exist %wixdir% goto nobuild

echo Updating Wix from %wixdir% ...

if exist %tempdir% (
    del /q %tempdir% >nul 2>&1
    rmdir /s /q %tempdir% >nul 2>&1
)

unzip -q %wixdir%\wix2-binaries.zip -d %tempdir%
if errorlevel 1 goto unziperr

copy %wixdir%\Votive2.msi %tempdir%
if errorlevel 1 goto copyerr1
copy %wixdir%\wix2-pdbs.zip %tempdir%
if errorlevel 1 goto copyerr2

call sdreflect -silent %tempdir% %inetroot%\public\ext\wix\wixv2
if errorlevel 1 goto reflecterr

rmdir /s /q %tempdir%

call sd.exe edit %inetroot%\public\ext\wix\version.txt
echo wix 2.0 build %wixbuild% from %wixdir%>%inetroot%\public\ext\wix\version.txt

exit /b 0

:syntax
echo Syntax: update.cmd ^<wix-build^>
echo Example: update.cmd 4117.0
echo     This will update wix from \\delivery\releases\wix\2.0.4117.0.
exit /b 1

:nobuild
echo ERROR: Wix build %wixbuild% does not exist or is not valid.
echo (%wixdir% does not exist.)
exit /b 1

:unziperr
echo ERROR: Unable to unzip %wixdir%\wix2-binaries.zip
exit /b 1

:copyerr1
echo ERROR: Unable to copy Votive2.msi from %wixdir%
exit /b 1

:copyerr2
echo ERROR: Unable to copy wix2-pdbs.zip from %wixdir%
exit /b 1

:reflecterr
echo ERROR running 'sdreflect' from temporary directory to enlistment.
exit /b 1
