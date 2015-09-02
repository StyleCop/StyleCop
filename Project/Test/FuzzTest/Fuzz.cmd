set FuzzRoot=%~dp0

set Fuzzer="%programfiles%\Microsoft\FileFuzzer\Fuzzer.exe"
set SAFuzzHarness="%TestBin%StyleCopFuzzTestHarness.exe"
set FuzzFilesDir="%FuzzRoot%\%FuzzFilesSubFolder%"
set FuzzOutputDir="%FuzzRoot%\Results"

rd /s /q %FuzzOutputDir%
md %FuzzOutputDir%
md %FuzzOutputDir%\FuzzedFiles
md %FuzzOutputDir%\Crashes
md %FuzzOutputDir%\Logs

%Fuzzer% /T %FuzzFilesDir% /N %FuzzOutputDir%\FuzzedFiles /V %FuzzOutputDir%\Crashes /L %FuzzOutputDir%\Logs /P %SAFuzzHarness% /TNM %Iterations%