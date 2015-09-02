PUSHD %PROJECTROOT%
IF NOT DEFINED BuildTarget SET BuildTarget=debug
SET TestResultFile=%PROJECTROOT%\test\TestBin\LocalTestRun.%BuildTarget%.Results.trx
IF EXIST %TestResultFile%  DEL /F /Q %TestResultFile% 
%MSTestPath%\mstest.exe /nologo /testmetadata:StyleCop.vsmdi /resultsfile:%TestResultFile% 
REM  /detail:testtype
POPD