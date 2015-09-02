ECHO ON
Echo.
ECHO **** Install Microsoft StyleCop BEGIN ***********************************
ECHO Install Log File: %VerifyInstallLog%
if exist %VerifyInstallLog% DEL /F /Q %VerifyInstallLog%
REM msiexec.exe /norestart /qb-! /i %PROJECTROOT%\src\bin\%BuildTarget%\Microsoft.StyleCop.msi NOVSSHUTDOWNCHECK=1 /lv %VerifyInstallLog%
msiexec.exe /i %PROJECTROOT%\InstallDrop\Debug\Microsoft.StyleCop.msi /l*v %VerifyInstallLog% /norestart /passive 
ECHO OFF
ECHO **** Install Microsoft StyleCop END *************************************