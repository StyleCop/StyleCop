CALL %STTOOLS%\NuGet\NuGet.exe pack %PROJECTROOT%\StyleCop.nuspec -o %1 -BasePath %1 -Version %2
CALL %STTOOLS%\NuGet\NuGet.exe pack %PROJECTROOT%\StyleCop.Resharper92.nuspec -o %1 -BasePath %1