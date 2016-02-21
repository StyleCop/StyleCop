PUSHD %PROJECTROOT%
IF NOT DEFINED BuildTarget SET BuildTarget=debug
SET TestResultFile=%PROJECTROOT%\test\TestBin\LocalTestRun.%BuildTarget%.Results.trx
IF EXIST %TestResultFile%  DEL /F /Q %TestResultFile% 

IF "%VSTESTSCRIPT%" == ""  (
  %MSTestPath%\mstest.exe /nologo /testmetadata:StyleCop.vsmdi /resultsfile:%TestResultFile% 
)
ELSE (
  msbuild.exe %VSTESTSCRIPT% /p:TestDropLocation=%TESTBIN%
)

REM  /detail:testtype
POPD