@echo off

REM Look at the correct registry key for VS
set VSRegKey=HKLM\Software\Microsoft\VisualStudio\9.0
if defined PROGRAMFILES(x86) SET VSRegKey=HKLM\Software\Wow6432Node\Microsoft\VisualStudio\9.0

REM Find the install directory. Need to do this outside the For statement to intercept stderr when the reg key doesn't exist.
set SdmTempQueryFile=%temp%\sdmregquery.txt
REG QUERY "%VSRegKey%" /v InstallDir > "%SdmTempQueryFile%" 2>nul

REM Set the SdmModelsDir to the VS private assemblies directory
for /F "tokens=2* delims=	 " %%A IN (%SdmTempQueryFile%) DO @SET SdmModelsDirCheck=%%B

REM Set VS's environment variables
if exist "%SdmModelsDirCheck%\..\..\vc\vcvarsall.bat" call "%SdmModelsDirCheck%\..\..\vc\vcvarsall.bat"

REM Verify existence of PrivateAssemblies
if exist "%SdmModelsDirCheck%\PrivateAssemblies" set SdmModelsDirCheck=%SdmModelsDirCheck%\PrivateAssemblies\
if not exist "%SdmModelsDirCheck%" echo Warning: The SDM Command Prompt cannot be initialized because Visual Studio 2008 Team Edition for Architects is not installed. To launch the SDM Command Prompt, Visual Studio 2008 Team Edition for Architects must be installed. & goto :CLEANUP


REM Get the directory with MSBuild.exe
for /F "tokens=2* delims=	 " %%A IN ('REG QUERY "HKLM\Software\Microsoft\.NetFramework" /v InstallRoot') DO @SET CLRInstallDir=%%B
if not exist "%CLRInstallDir%" echo Where is the CLR install directory %CLRInstallDir%?
for /F %%A IN ('dir /b %CLRInstallDir%\v2*') DO @SET v2CLRInstallDir=%CLRInstallDir%%%A
if not exist "%v2CLRInstallDir%" echo Warning: The CLR v2 directory %v2CLRInstallDir% does not exist

REM Check if the variables are already set
if "%SdmModelsDirCheck%" == "%SdmModelsDir%" echo sdmvars.bat has already been run. & goto :CLEANUP

REM Set the environment variables
set SdmModelsDir=%SdmModelsDirCheck%
set SdmToolsDir=%~dp0
set SdmPublicAssemblies=%SdmToolsDir%\..\..\common\assemblies
set Path=%SdmToolsDir%;%V2CLRInstallDir%;%Path%
echo SDM SDK environment variables set

:CLEANUP
REM Clear out the temp file and environment variables
if exist "%SdmTempQueryFile%" del "%SdmTempQueryFile%"
set VSRegKey=
set SdmTempQueryFile=
set SdmModelsDirCheck=
