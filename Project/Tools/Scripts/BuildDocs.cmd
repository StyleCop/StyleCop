@echo off 

SETLOCAL

CALL msbuild %PROJECTROOT%\Docs\Rules\BuildDocs.proj

ENDLOCAL