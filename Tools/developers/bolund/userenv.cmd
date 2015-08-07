SET PATH=%PATH%;%ENLISTMENTROOT%\Tools\developers\bolund

REM Load aliases

if exist "%ProgramFiles%\Araxis\Araxis Merge\Compare.exe" (
  SET "SDDIFF=%ProgramFiles%\Araxis\Araxis Merge\Compare.exe"
  SET "SDMERGE=%ProgramFiles%\Araxis\Araxis Merge\Compare.exe"
)

if exist "%ProgramFiles(x86)%\Araxis\Araxis Merge\Compare.exe" (
  SET "SDDIFF=%ProgramFiles(x86)%\Araxis\Araxis Merge\Compare.exe"
  SET "SDMERGE=%ProgramFiles(x86)%\Araxis\Araxis Merge\Compare.exe"
)

if "%IsWoW64%" == "1" (
  %STTOOLS%\alias.exe -f %PROJECTROOT%\Tools\developers\%USERNAME%\aliasesX64.pub
) else (
  %STTOOLS%\alias.exe -f %PROJECTROOT%\Tools\developers\%USERNAME%\aliasesX86.pub
)

GOTO :TheEnd

:TheEnd