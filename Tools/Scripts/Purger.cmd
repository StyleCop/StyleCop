@echo off
Echo Removing directories
rd /s /q %PROJECTROOT%\bin
rd /s /q %PROJECTROOT%\BuildDrop
rd /s /q %PROJECTROOT%\InstallDrop
rd /s /q %PROJECTROOT%\Src\AddIns\CSharp\Analyzers\obj
rd /s /q %PROJECTROOT%\Src\AddIns\CSharp\InternalAnalyzers\obj
rd /s /q %PROJECTROOT%\Src\AddIns\CSharp\Parser\obj
rd /s /q %PROJECTROOT%\Src\SettingsEditor\obj
rd /s /q %PROJECTROOT%\Src\StyleCop\bin
rd /s /q %PROJECTROOT%\Src\StyleCop\obj
rd /s /q %PROJECTROOT%\Src\VSPackage\obj
rd /s /q %PROJECTROOT%\Src\WixSetup\obj
rd /s /q %PROJECTROOT%\Test\AddIns\CSharp\Analyzers\CSharpAnalyzersTest\bin
rd /s /q %PROJECTROOT%\Test\AddIns\CSharp\Analyzers\CSharpAnalyzersTest\obj
rd /s /q %PROJECTROOT%\Test\AddIns\CSharp\Parser\CSharpParserTest\bin
rd /s /q %PROJECTROOT%\Test\AddIns\CSharp\Parser\CSharpParserTest\obj
rd /s /q %PROJECTROOT%\Test\AddIns\CSharp\Parser\CSharpParserTestRules\bin
rd /s /q %PROJECTROOT%\Test\AddIns\CSharp\Parser\CSharpParserTestRules\obj
rd /s /q %PROJECTROOT%\Test\Harnesses\PerfHarness\obj
rd /s /q %PROJECTROOT%\Test\Harnesses\StyleCopRunDir\obj
rd /s /q %PROJECTROOT%\Test\Harnesses\TestHarness\bin
rd /s /q %PROJECTROOT%\Test\Harnesses\TestHarness\obj
rd /s /q %PROJECTROOT%\Test\TestBin
rd /s /q %PROJECTROOT%\Test\VSPackageUnitTest\obj
rd /s /q %PROJECTROOT%\TestResults

Echo Removing files
del /q %PROJECTROOT%\Build.debug.wrn
del /q %PROJECTROOT%\Build.Release.wrn
del /q %PROJECTROOT%\Src\AddIns\CSharp\Analyzers\StyleCop.Cache
del /q %PROJECTROOT%\Src\AddIns\CSharp\InternalAnalyzers\StyleCop.Cache
del /q %PROJECTROOT%\Src\AddIns\CSharp\Parser\StyleCop.Cache
del /q %PROJECTROOT%\Src\SettingsEditor\StyleCop.Cache
del /q %PROJECTROOT%\Src\StyleCop\StyleCop.Cache
del /q %PROJECTROOT%\Src\VSPackage\StyleCop.Cache
del /q %PROJECTROOT%\Src\WixSetup\Build.debug.wrn
del /q %PROJECTROOT%\Src\WixSetup\Build.Release.wrn
del /q %PROJECTROOT%\Test\Harnesses\TestHarness\StyleCop.Cache
REM del /q %PROJECTROOT%\Tools\Scripts\Log.Uninstall.txt