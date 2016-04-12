CALL %STTOOLS%\NuGet\NuGet.exe pack %PROJECTROOT%\StyleCop.nuspec -o %1 -BasePath %1 -Version %2
CALL %STTOOLS%\NuGet\NuGet.exe pack %PROJECTROOT%\StyleCop.Resharper920.nuspec -o %1 -BasePath %1
CALL %STTOOLS%\NuGet\NuGet.exe pack %PROJECTROOT%\StyleCop.Resharper1000.nuspec -o %1 -BasePath %1