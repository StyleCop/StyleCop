@echo off 

SETLOCAL

PUSHD %PROJECTROOT%\src\WixSetup\
REM Default value for parameters
SET Flavor=debug


:Params
IF "%1"=="" GOTO ParamsDone

REM Set Flavor
FOR %%a IN (.- ./) DO IF /I ".%1" == "%%aRETAIL" ( SET Flavor=Release& SHIFT & GOTO Params )
FOR %%a IN (.- ./) DO IF /I ".%1" == "%%aRELEASE" ( SET Flavor=Release& SHIFT & GOTO Params )
IF /I "%1" == "RETAIL" ( SET Flavor=Release& SHIFT & GOTO Params )
IF /I "%1" == "aRELEASE" ( SET Flavor=Release& SHIFT & GOTO Params )

:ParamsDone

CALL msbuild WixSetup.wixproj /p:Configuration=%Flavor%

POPD

ENDLOCAL