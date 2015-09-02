@echo off 

SETLOCAL

CALL msbuild %PROJECTROOT%\Docs\Rules\BuildDocs.proj
CALL msbuild %PROJECTROOT%\Docs\Sdk\BuildDocs.proj

ENDLOCAL