@echo off

echo.
echo.
echo **************************************************************************************************************
echo Adding MSBuild safe imports for this enlistment.
echo **************************************************************************************************************
echo.

call powershell.exe -command . .\MsBuildSafeImports.ps1; "& add-safeimports" 
