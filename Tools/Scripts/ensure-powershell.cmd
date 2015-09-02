@setlocal
@if not defined _echo echo off
set COMPLUS_VERSION=v2.0.50727
:: 
:: Ensure-PowerShell.cmd
:: 
:: Ensure that PowerShell is installed on any machine

set echo=echo %~n0:

::
:: check if PowerShell is already installed
::
REG QUERY "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\PowerShell\1\ShellIds\Microsoft.PowerShell" /v ExecutionPolicy >nul 2>&1
if "%ERRORLEVEL%" == "1" set BADREG=Yes

for %%I in (powershell.exe) do if NOT (%%~$PATH:I) == () (
   if "%BADREG%"=="Yes" Call :SetExecutionPolicy
)



for %%I in (powershell.exe) do if NOT (%%~$PATH:I) == () (
    Set IsInstalled=Yes
    FOR /F "tokens=3,* delims=	 " %%i in ( 'REG QUERY "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\PowerShell\1\ShellIds\Microsoft.PowerShell" /v ExecutionPolicy' ) DO (
        IF not "%%i"=="RemoteSigned" Call :SetExecutionPolicy
    )
    
    exit /b 0
)

If "%IsInstalled%" == "" (
    if exist "%SystemRoot%\System32\WindowsPowerShell\v1.0\Powershell.exe" (
	Set SetPath=Yes
        Set IsInstalled=Yes
    )
)


If "%IsInstalled%" == "Yes" (
    %echo% PowerShell already installed..

    FOR /F "tokens=3,* delims=	 " %%i in ( 'REG QUERY "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\PowerShell\1\ShellIds\Microsoft.PowerShell" /v ExecutionPolicy' ) DO (
        IF not "%%i"=="RemoteSigned" (
	    Set PSPolicy=Yes
  	)
    )
)

If "%IsInstalled%" == "Yes" (

    if "%SetPath%" == "Yes" (
	call :addpath %SystemRoot%\System32\WindowsPowerShell\v1.0\
    )

    
    if /i "%PSPolicy%" == "Yes" (
	call :SetExecutionPolicy
    )

    if "%SetPath%" == "Yes" (
	@endlocal
	call :addpath %SystemRoot%\System32\WindowsPowerShell\v1.0\
    )
    exit /b 0
)


set PowerShell_InstallRoot=%InetRoot%\public\ext\powershell

::
:: Extract the version number of the local Windows system.
::
for /f "tokens=4,5 delims=.]XP " %%i in ('ver') do set VER=%%i.%%j
for /f "tokens=4,5,6 delims=.]XP " %%i in ('ver') do set FULLVER=%%i.%%j.%%k

%echo% Parsed VER=%VER% and FULLVER=%FULLVER%

if "%VER%" == "5.1" (

    if "%PROCESSOR_ARCHITECTURE%" == "x86" (
	%echo% selecting PowerShell installer for Windows XP ^(X86^)
	set Installer=%PowerShell_InstallRoot%\WindowsXP-KB926139-x86-ENU.exe /passive
    ) else (
	%echo% selecting PowerShell installer for Windows XP ^(X64^)
	set Installer=%PowerShell_InstallRoot%\WindowsServer2003.WindowsXP-KB926139-x64-ENU.exe /passive
    )	

) else if "%VER%" == "5.2" (

    if "%PROCESSOR_ARCHITECTURE%" == "x86" (
	%echo% selecting PowerShell installer for Windows Server 2003 ^(X86^)	
	set Installer=%PowerShell_InstallRoot%\WindowsServer2003-KB926139-x86-ENU.exe /passive
    ) else (
	%echo% selecting PowerShell installer for Windows Server 2003 ^(X64^)	
 	set Installer=%PowerShell_InstallRoot%\WindowsServer2003.WindowsXP-KB926139-x64-ENU.exe /passive
	    %echo% Selected
    )	


) else if "%VER%" == "6.0" (

    if "%FULLVER%" == "6.0.6000" (
	if "%PROCESSOR_ARCHITECTURE%" == "x86" (
	    %echo% selecting PowerShell installer for Windows Vista ^(X86^)
	    set Installer=%PowerShell_InstallRoot%\Windows6.0-KB928439-x86.msu /quiet
	) else (
	    %echo% selecting PowerShell installer for Windows Vista ^(X64^)
	    set Installer=%PowerShell_InstallRoot%\Windows6.0-KB928439-x64.msu /quiet

	)	    
    ) else (
        %echo% This install script only works for Vista RTM and some random build of Longhorn Server, not %FULLVER%
        exit /b 1
    )

) else (

    %echo% Could not understand version string of %VER%.
    %echo%.
    %echo% If you're on Longhorn Server Beta 3 or later, PowerShell is now an "optional component". 
    %echo% Install the latest LH server builds from \\winbuilds\release\longhorn.
    %echo% To get powershell, launch Server Manager--> Features --> Add Features --> Select Windows Powershell
    
    exit /b 1
)


%echo% calling %Installer%
call %Installer%
	
@endlocal
call :addpath %SystemRoot%\System32\WindowsPowerShell\v1.0\

call :SetExecutionPolicy

exit /b 0

goto :EOF

:addpath
set path=%PATH%;%1
goto :EOF


:SetExecutionPolicy

    if "%PROCESSOR_ARCHITECTURE%" == "x86" (
	PowerShell -Command Set-ExecutionPolicy -Verbose RemoteSigned
    ) else (
	%SYSTEMROOT%\System32\WindowsPowerShell\v1.0\powershell.exe -Command Set-ExecutionPolicy -Verbose RemoteSigned
	%SYSTEMROOT%\SysWOW64\WindowsPowerShell\v1.0\powershell.exe -Command Set-ExecutionPolicy -Verbose RemoteSigned
    )	
goto :EOF