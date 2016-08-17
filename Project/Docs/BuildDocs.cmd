@echo off 

SETLOCAL

CALL "%windir%\Microsoft.NET\Framework\v4.0.30319\msbuild.exe" %~dp0\Rules\BuildDocs.proj
CALL "%windir%\Microsoft.NET\Framework\v4.0.30319\msbuild.exe" %~dp0\Sdk\BuildDocs.proj

ENDLOCAL