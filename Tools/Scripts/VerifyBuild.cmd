@ECHO OFF

SETLOCAL

SET /p AssemblyVersion=<"%PROJECTROOT%\src\AssemblyVersion.txt"

REM Default value for parameters
SET BuildTarget=Debug
SET SkipBuild=0
SET SkipTests=0
SET NoInstall=1
SET NoUninstall=0
SET SkipTests=0
SET NoBuild=0
SET NoNuke=0
SET NoSync=0
SET SkipWixBuild=0
SET WixBuildOnly=0
SET NoCodeAnalysis=0
SET BuildDocs=0

SET VerifyInstallLog=%TEMP%\StyleCop.VerifyBuild.Install.Log
REM *** Parse script parameters ***
:Params
IF "%1"=="" GOTO ParamsDone

REM Show help if -?
FOR %%a IN (.- ./) DO IF ".%~1." == "%%a?." ( GOTO Usage )

REM Skip build if -testsonly
FOR %%a IN (.- ./) DO IF /I ".%1" == "%%aTESTSONLY" ( SET SkipBuild=1& SHIFT & GOTO Params )
FOR %%a IN (.- ./) DO IF /I ".%1" == "%%aTESTONLY" ( SET SkipBuild=1& SHIFT & GOTO Params )

REM Skip file check if -notest
FOR %%a IN (.- ./) DO IF /I ".%1" == "%%aNOTEST" ( SET SkipTests=1& SHIFT & GOTO Params )
FOR %%a IN (.- ./) DO IF /I ".%1" == "%%aNOTESTS" ( SET SkipTests=1& SHIFT & GOTO Params )

REM Skip file nuke if -nonuke
FOR %%a IN (.- ./) DO IF /I ".%1" == "%%aNONUKE" ( SET NoNuke=1& SHIFT & GOTO Params )

REM Skip sd sync if -nosync
FOR %%a IN (.- ./) DO IF /I ".%1" == "%%aNOSYNC" ( SET NoSync=1& SHIFT & GOTO Params )

REM Skip build if -nobuild
FOR %%a IN (.- ./) DO IF /I ".%1" == "%%aNOBUILD" ( SET NoBuild=1& SHIFT & GOTO Params )

REM Skip install if -NoInstall
FOR %%a IN (.- ./) DO IF /I ".%1" == "%%aNOINSTALL" ( SET NoInstall=1& SHIFT & GOTO Params )

REM Skip uninstall if -NoUninstall
FOR %%a IN (.- ./) DO IF /I ".%1" == "%%aNOUNINSTALL" ( SET NoUninstall=1& SHIFT & GOTO Params )

REM Skip WixBuild if -SkipWixBuild
FOR %%a IN (.- ./) DO IF /I ".%1" == "%%aSKIPWIXBUILD" ( SET SkipWixBuild=1& SHIFT & GOTO Params )

REM Only build Wix if -WixBuildOnly
FOR %%a IN (.- ./) DO IF /I ".%1" == "%%aWIXBUILDONLY" ( SET WixBuildOnly=1& SHIFT & GOTO Params )

REM Skip Code Analysis if -NoCodeAnalysis
FOR %%a IN (.- ./) DO IF /I ".%1" == "%%aNOCODEANALYSIS" ( SET NoCodeAnalysis=1& SHIFT & GOTO Params )

REM Build Documentation if -Docs
FOR %%a IN (.- ./) DO IF /I ".%1" == "%%aDOCS" ( SET BuildDocs=1& SHIFT & GOTO Params )

REM Set BuildTarget
FOR %%a IN (.- ./) DO IF /I ".%1" == "%%aRETAIL" ( SET BuildTarget=Release& SHIFT & GOTO Params )
IF /I "%1" == "RETAIL" ( SET BuildTarget=Release&SET NoCodeAnalysis=1& SHIFT & GOTO Params )

REM -BuildAndDeploy /  Build Installer And Deploy MSI
FOR %%a IN (.- ./) DO IF /I ".%1" == "%%aBUILDANDDEPLOY" ( SET BuildAndDeploy=true& SHIFT & GOTO Params )

:ParamsDone

GOTO ParametersListDone
ECHO BuildTarget     : %BuildTarget%
ECHO SkipBuild       : %SkipBuild%
ECHO SkipTests       : %SkipTests%
ECHO NoInstall       : %NoInstall%
ECHO NoUninstall     : %NoUninstall%
ECHO SkipTests       : %SkipTests%
ECHO NoBuild         : %NoBuild%
ECHO NoNuke          : %NoNuke%
ECHO NoSync          : %NoSync%
ECHO SkipWixBuild    : %SkipWixBuild%
ECHO NoCodeAnalysis  : %NoCodeAnalysis%
ECHO WixBuildOnly    : %WixBuildOnly%
:ParametersListDone

:Usage
Echo.
ECHO Usage:
Echo VerifyBuild.cmd [retail] [-NoSync] [-NoNuke] [-TestOnly] [-NoBuild] [-NoTests] [-Retail] [-SkipWixBuild] [-WixBuildOnly] [-NoCodeAnalysis]
REM [-BuildAndDeploy] [-NoInstall] [-NoUninstall]

IF "%BuildTarget%"=="Release" (
	IF %ReSharperFound%==0 (
                echo .
		echo Cannot continue with Release build unless ReSharper is installed.
		echo .
		EXIT /B
	)
)

IF "%BuildTarget%"=="Debug" (
	IF %ReSharperFound%==0 (
                SET BuildTarget=Debug.NoReSharper
		SET SkipWixBuild=1
	)
)

PUSHD %PROJECTROOT%\

IF %WixBuildOnly%.==1. GOTO WIXBUILD
IF %SkipBuild%.==1. GOTO TEST

:Uninstall
IF %NoUninstall%.==1. GOTO PostUninstall
Echo.
ECHO **** Uninstall product BEGIN *********************************************
CALL  %PROJECTROOT%\src\WixSetup\UninstallMsi.bat
SET MsiUninstallExitCode=%EXITCODE%

REM IF NOT %MsiUninstallExitCode%==0 (
REM    ECHO Uninstall MSI finishes with errors.
REM    ECHO Verifybuild will proceed with building, but will not perform installation and tests 
REM )

ECHO **** Uninstall product END ***********************************************
:PostUninstall

IF %NoBuild%.==1. GOTO INSTALL

:NUKE
IF %NoNuke%.==1. GOTO POSTNUKE
Echo.
ECHO **** Purge enlistment BEGIN **********************************************
Echo Purge enlistment
CALL %STTOOLS%\Scripts\Purger.cmd
:POSTNUKE

:SYNC
IF %NoSync%.==1. GOTO BUILD
Echo.
ECHO **** Sync enlistment BEGIN ***********************************************
call cpc update
REM call sd resolve -am
REM FOR /F %%i IN ('sd resolve -n') DO GOTO FilesMustBeResolved
GOTO PostResolve

:FilesMustBeResolved
ECHO.
ECHO The following files must be resolved:
call sd resolve -n
EXIT /B
:PostResolve
ECHO **** Sync enlistment END *************************************************

:BUILD
ECHO.
ECHO **** Build %BuildTarget% BEGIN *************************************************

REM Restore NuGet Packages
%STTOOLS%\NuGet\nuget.exe restore %PROJECTROOT%
IF %ERRORLEVEL% neq 0 echo failed. %errorlevel% && exit /b %errorlevel%

REM Make warnings appear as build errors.
SET StyleCopTreatErrorsAsWarnings=false
SET CodeAnalysisTreatWarningsAsErrors=true
SET TreatWarningsAsErrors=true

REM Enable or Disable Code Analysis
IF "%NOCODEANALYSIS%" == "0" SET RunCodeAnalysis=true
IF "%NOCODEANALYSIS%" == "1" SET RunCodeAnalysis=false

SET BuildLogFile=Build.%BuildTarget%

REM Build Main Solution
IF EXIST %PROJECTROOT%\%BuildLogFile%.wrn DEL /F /Q %PROJECTROOT%\%BuildLogFile%.wrn
IF EXIST %PROJECTROOT%\%BuildLogFile%.err DEL /F /Q %PROJECTROOT%\%BuildLogFile%.err
CALL "%windir%\microsoft.net\framework\%FrameworkVersion%\msbuild.exe" %PROJECTROOT%\StyleCop.sln /p:VisualStudioVersion=12.0;Configuration=%BuildTarget%;CODE_ANALYSIS=true /flp1:warningsonly;logfile=%PROJECTROOT%\%BuildLogFile%.wrn /flp2:errorsonly;logfile=%PROJECTROOT%\%BuildLogFile%.err
IF "%ERRORLEVEL%" == "0" DEL /F /Q %PROJECTROOT%\%BuildLogFile%.err
CALL %STTOOLS%\Scripts\DeleteEmptyFile.cmd %PROJECTROOT%\%BuildLogFile%.wrn
IF "%ERRORLEVEL%" == "1" GOTO SUMMARY

REM Build Setup Solution
:WIXBUILD
IF EXIST %PROJECTROOT%\src\WixSetup\%BuildLogFile%.wrn DEL /F /Q %PROJECTROOT%\src\WixSetup\%BuildLogFile%.wrn
IF EXIST %PROJECTROOT%\src\WixSetup\%BuildLogFile%.err DEL /F /Q %PROJECTROOT%\src\WixSetup\%BuildLogFile%.err

IF "%SkipWixBuild%" == "1" GOTO PostWixBuild

SET WixBuildTarget=%BuildTarget%

IF "%BuildTarget%" == "Debug.NoReSharper" SET WixBuildTarget=Debug

CALL "%windir%\microsoft.net\framework\v3.5\msbuild.exe" %PROJECTROOT%\src\wixsetup\StyleCop.Wix.sln /p:Configuration=%WixBuildTarget% /flp1:warningsonly;logfile=%PROJECTROOT%\src\wixsetup\%buildlogfile%.wrn /flp2:errorsonly;logfile=%PROJECTROOT%\src\wixsetup\%buildlogfile%.err
IF "%ERRORLEVEL%" == "0" DEL /F /Q %PROJECTROOT%\src\WixSetup\%BuildLogFile%.err
CALL %STTOOLS%\Scripts\DeleteEmptyFile.cmd %PROJECTROOT%\src\WixSetup\%BuildLogFile%.wrn
IF "%ERRORLEVEL%" == "1" GOTO SUMMARY
IF %WixBuildOnly%.==1. GOTO SUMMARY
:PostWixBuild

ECHO **** Build %BuildTarget% END ***************************************************

:INSTALL
IF %NoInstall%.==1. GOTO PostInstall
CALL %STTOOLS%\Scripts\InstallProduct.cmd
:PostInstall

IF %SkipTests%.==1. GOTO SUMMARY

:TEST
Echo.
ECHO **** Run tests BEGIN ***********************************************************
CALL %STTOOLS%\Scripts\RunTests.cmd
IF "%ERRORLEVEL%" == "1" GOTO SUMMARY
REM 
REM 
ECHO **** Run tests END *************************************************************

:NUGET
REM Build NuGet package
CALL %STTOOLS%\Scripts\CreateNuGetPackage.cmd %PROJECTROOT%\BuildDrop\%BuildTarget% %AssemblyVersion%
COPY "%PROJECTROOT%\BuildDrop\%BuildTarget%\StyleCop.%AssemblyVersion%.nupkg" "%PROJECTROOT%\InstallDrop\%BuildTarget%\StyleCop.%AssemblyVersion%.nupkg"

:RELEASENOTES
CALL "hg.exe" log >%PROJECTROOT%\BuildDrop\%BuildTarget%\ChangeHistory.txt
CALL %STTOOLS%\HgReleaseNotesGen\HgReleaseNotesGen.exe %PROJECTROOT%\BuildDrop\%BuildTarget%\ChangeHistory.txt %PROJECTROOT%\Docs\ReleaseHistory.txt %PROJECTROOT%\InstallDrop\%BuildTarget%\ReleaseNotes.txt

REM IF "%BuildTarget%" neq "Release" GOTO SUMMARY

:SIGNING

echo Checking Code Signing...

if "%USERNAME%" neq "andy" goto :done
if not exist "c:\AndrewReevesCodeSigning.pfx" goto :done

echo Signing msi...

signtool.exe sign /f "c:\AndrewReevesCodeSigning.pfx" /t "http://timestamp.verisign.com/scripts/timestamp.dll" /d "StyleCop" /du "http://stylecop.codeplex.com" "%PROJECTROOT%\InstallDrop\%BuildTarget%\StyleCop.msi"

echo Renaming StyleCop.msi as StyleCop-%AssemblyVersion%.msi

COPY "%PROJECTROOT%\InstallDrop\%BuildTarget%\StyleCop.msi" "%PROJECTROOT%\InstallDrop\%BuildTarget%\StyleCop-%AssemblyVersion%.msi"
DEL "%PROJECTROOT%\InstallDrop\%BuildTarget%\StyleCop.msi"

IF "%BuildTarget%" equ "Release" GOTO :done

COPY "%PROJECTROOT%\InstallDrop\%BuildTarget%\StyleCop-%AssemblyVersion%.msi" "%PROJECTROOT%\InstallDrop\%BuildTarget%\StyleCop-%AssemblyVersion%-Debug.msi"
DEL "%PROJECTROOT%\InstallDrop\%BuildTarget%\StyleCop-%AssemblyVersion%.msi"

:done

echo Done.

:SUMMARY

IF "%SkipBuild%" == "1" Goto :END

ECHO.
ECHO **** BUILD SUMMARY BEGIN *********************************************
ECHO.
if exist %PROJECTROOT%\%BuildLogFile%.wrn (
    ECHO %BuildTarget% build is finished with warnings - please fix them. See %PROJECTROOT%\%BuildLogFile%.wrn for details
)
if exist %PROJECTROOT%\src\WixSetup\%BuildLogFile%.wrn (
    ECHO %BuildTarget% build is finished with warnings - please fix them. See %PROJECTROOT%\src\WixSetup\%BuildLogFile%.wrn for details
)

SET GOTOEND=
if exist %PROJECTROOT%\%BuildLogFile%.err (
    ECHO %BuildTarget% build is finished with errors. See %PROJECTROOT%\%BuildLogFile%.err for details
    SET GOTOEND=1
)

if exist %PROJECTROOT%\src\WixSetup\%BuildLogFile%.err (
    ECHO %BuildTarget% wix build is finished with errors. See %PROJECTROOT%\src\WixSetup\%BuildLogFile%.err for details
    SET GOTOEND=1
)

IF %GOTOEND%.==1. GOTO :END

IF NOT %BuildDocs%.==1. GOTO :END
call %PROJECTROOT%\Docs\BuildDocs.cmd

ECHO.
ECHO **** BUILD SUMMARY END ***********************************************
ECHO.

:END
