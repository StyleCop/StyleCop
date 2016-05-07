@echo off
Echo Removing directories
rd /s /q %~dp0..\..\Project\bin
rd /s /q %~dp0..\..\Project\BuildDrop
rd /s /q %~dp0..\..\Project\InstallDrop
rd /s /q %~dp0..\..\Project\Src\AddIns\CSharp\Analyzers\obj
rd /s /q %~dp0..\..\Project\Src\AddIns\CSharp\InternalAnalyzers\obj
rd /s /q %~dp0..\..\Project\Src\AddIns\CSharp\Parser\obj
rd /s /q %~dp0..\..\Project\Src\SettingsEditor\obj
rd /s /q %~dp0..\..\Project\Src\StyleCop\bin
rd /s /q %~dp0..\..\Project\Src\StyleCop\obj
rd /s /q %~dp0..\..\Project\Src\VSPackage\obj
rd /s /q %~dp0..\..\Project\Src\WixSetup\obj
rd /s /q %~dp0..\..\Project\Test\AddIns\CSharp\Analyzers\CSharpAnalyzersTest\bin
rd /s /q %~dp0..\..\Project\Test\AddIns\CSharp\Analyzers\CSharpAnalyzersTest\obj
rd /s /q %~dp0..\..\Project\Test\AddIns\CSharp\Parser\CSharpParserTest\bin
rd /s /q %~dp0..\..\Project\Test\AddIns\CSharp\Parser\CSharpParserTest\obj
rd /s /q %~dp0..\..\Project\Test\AddIns\CSharp\Parser\CSharpParserTestRules\bin
rd /s /q %~dp0..\..\Project\Test\AddIns\CSharp\Parser\CSharpParserTestRules\obj
rd /s /q %~dp0..\..\Project\Test\Harnesses\PerfHarness\obj
rd /s /q %~dp0..\..\Project\Test\Harnesses\StyleCopRunDir\obj
rd /s /q %~dp0..\..\Project\Test\Harnesses\TestHarness\bin
rd /s /q %~dp0..\..\Project\Test\Harnesses\TestHarness\obj
rd /s /q %~dp0..\..\Project\Test\TestBin
rd /s /q %~dp0..\..\Project\Test\VSPackageUnitTest\obj
rd /s /q %~dp0..\..\Project\TestResults

Echo Removing files
del /q %~dp0..\..\Project\Build.debug.wrn
del /q %~dp0..\..\Project\Build.Release.wrn
del /q %~dp0..\..\Project\Src\AddIns\CSharp\Analyzers\StyleCop.Cache
del /q %~dp0..\..\Project\Src\AddIns\CSharp\InternalAnalyzers\StyleCop.Cache
del /q %~dp0..\..\Project\Src\AddIns\CSharp\Parser\StyleCop.Cache
del /q %~dp0..\..\Project\Src\SettingsEditor\StyleCop.Cache
del /q %~dp0..\..\Project\Src\StyleCop\StyleCop.Cache
del /q %~dp0..\..\Project\Src\VSPackage\StyleCop.Cache
del /q %~dp0..\..\Project\Src\WixSetup\Build.debug.wrn
del /q %~dp0..\..\Project\Src\WixSetup\Build.Release.wrn
del /q %~dp0..\..\Project\Test\Harnesses\TestHarness\StyleCop.Cache
REM del /q %~dp0..\..\Project\Tools\Scripts\Log.Uninstall.txt