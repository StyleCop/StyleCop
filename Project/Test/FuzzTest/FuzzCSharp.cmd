setlocal

set root=%~dp0
rd /s /q %root%\CSharp
md %root%\CSharp
xcopy /e %PROJECTROOT%\Test\AddIns\CSharp\*.cs %root%\CSharp
xcopy /e %PROJECTROOT%\Src\StyleCop\*.cs %root%\CSharp

set FuzzFilesSubFolder=CSharp
set Iterations=10000

call %~dp0\Fuzz.cmd

endlocal