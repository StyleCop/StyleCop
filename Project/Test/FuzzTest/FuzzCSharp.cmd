setlocal

set root=%~dp0
rd /s /q %root%\CSharp
md %root%\CSharp
xcopy /e %~dp0..\AddIns\CSharp\*.cs %root%\CSharp
xcopy /e %~dp0..\..\Src\StyleCop\*.cs %root%\CSharp

set FuzzFilesSubFolder=CSharp
set Iterations=10000

call %~dp0\Fuzz.cmd

endlocal