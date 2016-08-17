SET PATH=%PATH%;%~dp0\bolund

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
  %~dp0..\..\alias.exe -f %~dp0\aliasesX64.pub
) else (
  %~dp0..\..\alias.exe -f %~dp0\aliasesX86.pub
)

GOTO :TheEnd

:TheEnd