@ECHO OFF

SET /p AssemblyVersion=<"%~dp0..\..\Project\src\AssemblyVersion.txt"

REM Default value for parameters
SET BuildTarget=Debug
SET BuildDocs=0

SET VerifyInstallLog=%TEMP%\StyleCop.VerifyBuild.Install.Log
REM *** Parse script parameters ***
:Params
IF "%1"=="" GOTO ParamsDone

REM Show help if -?
FOR %%a IN (.- ./) DO IF ".%~1." == "%%a?." ( GOTO Usage )

REM Build Documentation if -Docs
FOR %%a IN (.- ./) DO IF /I ".%1" == "%%aDOCS" ( SET BuildDocs=1& SHIFT & GOTO Params )

REM Set BuildTarget
FOR %%a IN (.- ./) DO IF /I ".%1" == "%%aRETAIL" ( SET BuildTarget=Release& SHIFT & GOTO Params )
IF /I "%1" == "RETAIL" ( SET BuildTarget=Release& SHIFT & GOTO Params )

:ParamsDone

:Usage
Echo.
ECHO Usage:
Echo VerifyBuild.cmd [-Retail] [-Docs]

Echo.
ECHO **** Uninstall product BEGIN *********************************************
msiexec  /qb-! /x {3175553C-88D5-453B-93CB-4012A827533A} /quiet /l*v %~dp0Log.Uninstall.txt NOVSSHUTDOWNCHECK=1
echo Logged uninstall result to %~dp0\Log.Uninstall.txt 

ECHO **** Uninstall product END ***********************************************

Echo.
ECHO **** Purge enlistment BEGIN **********************************************
Echo Purge enlistment
CALL %~dp0\Purger.cmd

ECHO.
ECHO **** Build %BuildTarget% BEGIN *************************************************

REM Make warnings appear as build errors.
SET StyleCopTreatErrorsAsWarnings=false
SET CodeAnalysisTreatWarningsAsErrors=true
SET TreatWarningsAsErrors=true

SET BuildLogFile=Build.%BuildTarget%

REM Build Main Solution
IF EXIST %~dp0..\..\Project\%BuildLogFile%.wrn DEL /F /Q %~dp0..\..\Project\%BuildLogFile%.wrn
IF EXIST %~dp0..\..\Project\%BuildLogFile%.err DEL /F /Q %~dp0..\..\Project\%BuildLogFile%.err
CALL "%programfiles(x86)%\MSBuild\14.0\Bin\msbuild.exe" %~dp0..\..\Project\StyleCop.sln /p:VisualStudioVersion=14.0;Configuration=%BuildTarget%;CODE_ANALYSIS=true /flp1:warningsonly;logfile=%~dp0..\..\Project\%BuildLogFile%.wrn /flp2:errorsonly;logfile=%~dp0..\..\Project\%BuildLogFile%.err
IF "%ERRORLEVEL%" == "0" DEL /F /Q %~dp0..\..\Project\%BuildLogFile%.err
CALL %~dp0\DeleteEmptyFile.cmd %~dp0..\..\Project\%BuildLogFile%.wrn
IF "%ERRORLEVEL%" == "1" GOTO SUMMARY

REM Build Setup Solution
IF EXIST %~dp0..\..\Project\src\WixSetup\%BuildLogFile%.wrn DEL /F /Q %~dp0..\..\Project\src\WixSetup\%BuildLogFile%.wrn
IF EXIST %~dp0..\..\Project\src\WixSetup\%BuildLogFile%.err DEL /F /Q %~dp0..\..\Project\src\WixSetup\%BuildLogFile%.err

SET WixBuildTarget=%BuildTarget%

CALL "%windir%\Microsoft.NET\Framework64\v4.0.30319\msbuild.exe" %~dp0..\..\Project\src\wixsetup\StyleCop.Wix.sln /p:Configuration=%WixBuildTarget% /flp1:warningsonly;logfile=%~dp0..\..\Project\src\wixsetup\%buildlogfile%.wrn /flp2:errorsonly;logfile=%~dp0..\..\Project\src\wixsetup\%buildlogfile%.err
IF "%ERRORLEVEL%" == "0" DEL /F /Q %~dp0..\..\Project\src\WixSetup\%BuildLogFile%.err
CALL %~dp0\DeleteEmptyFile.cmd %~dp0..\..\Project\src\WixSetup\%BuildLogFile%.wrn
IF "%ERRORLEVEL%" == "1" GOTO SUMMARY

ECHO **** Build %BuildTarget% END ***************************************************

Echo.
ECHO **** Run tests BEGIN ***********************************************************
CALL "%programfiles(x86)%\Microsoft Visual Studio 14.0\Common7\IDE\CommonExtensions\Microsoft\TestWindow\VSTest.Console.exe" /Platform:x86 /Framework:framework40 %~dp0..\..\Project\Test\TestBin\Release\CSharpAnalyzersTest.dll %~dp0..\..\Project\Test\TestBin\Release\CSharpParserTest.dll %~dp0..\..\Project\Test\TestBin\Release\CSharpParserTestRules.dll %~dp0..\..\Project\Test\TestBin\Release\ObjectBasedEnvironmentTest.dll %~dp0..\..\Project\Test\TestBin\Release\StyleCop.Test.dll %~dp0..\..\Project\Test\TestBin\Release\VSPackageUnitTest.dll
IF "%ERRORLEVEL%" == "1" GOTO SUMMARY
ECHO **** Run tests END *************************************************************

:NUGET
REM Copy NuGet packages to InstallDrop folder
COPY "%~dp0..\..\Project\BuildDrop\%BuildTarget%\*.nupkg" "%~dp0..\..\Project\InstallDrop\%BuildTarget%"

:RELEASENOTES
CALL "hg.exe" log >%~dp0..\..\Project\BuildDrop\%BuildTarget%\ChangeHistory.txt
CALL %~dp0..\HgReleaseNotesGen\HgReleaseNotesGen.exe %~dp0..\..\Project\BuildDrop\%BuildTarget%\ChangeHistory.txt %~dp0..\..\Project\Docs\ReleaseHistory.txt %~dp0..\..\Project\InstallDrop\%BuildTarget%\ReleaseNotes.txt

echo Done.

:SUMMARY

ECHO.
ECHO **** BUILD SUMMARY BEGIN *********************************************
ECHO.
if exist %~dp0..\..\Project\%BuildLogFile%.wrn (
    ECHO %BuildTarget% build is finished with warnings - please fix them. See %~dp0..\..\Project\%BuildLogFile%.wrn for details
)
if exist %~dp0..\..\Project\src\WixSetup\%BuildLogFile%.wrn (
    ECHO %BuildTarget% build is finished with warnings - please fix them. See %~dp0..\..\Project\src\WixSetup\%BuildLogFile%.wrn for details
)

SET GOTOEND=
if exist %~dp0..\..\Project\%BuildLogFile%.err (
    ECHO %BuildTarget% build is finished with errors. See %~dp0..\..\Project\%BuildLogFile%.err for details
    SET GOTOEND=1
)

if exist %~dp0..\..\Project\src\WixSetup\%BuildLogFile%.err (
    ECHO %BuildTarget% wix build is finished with errors. See %~dp0..\..\Project\src\WixSetup\%BuildLogFile%.err for details
    SET GOTOEND=1
)

IF %GOTOEND%.==1. GOTO :END

IF NOT %BuildDocs%.==1. GOTO :END
call %~dp0..\..\Project\Docs\BuildDocs.cmd

ECHO.
ECHO **** BUILD SUMMARY END ***********************************************
ECHO.

:END
