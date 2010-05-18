REM --------------------------------------------------------------------------------------
REM Set up the PROJECTROOT and ENLISTMENTROOT environment variables

set PROJECTROOT=%~dp0..

:LOOP
IF NOT EXIST "%PROJECTROOT%\0proot" (
    set PROJECTROOT=%PROJECTROOT%\..
    goto LOOP
)

set ENLISTMENTROOT=%PROJECTROOT%

:LOOP2
IF NOT EXIST "%ENLISTMENTROOT%\0root " (
    set ENLISTMENTROOT=%ENLISTMENTROOT%\..
    goto LOOP2
)