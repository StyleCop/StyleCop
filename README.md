# StyleCop

[![Gitter](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/StyleCop/StyleCop?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

StyleCop analyzes C# source code to enforce a set of style and consistency rules. It is available in two primary forms:

1. The [StyleCop Visual Studio extension](https://visualstudiogallery.msdn.microsoft.com/5441d959-387f-4cb2-a8c0-9998dd1fa49f), which allows StyleCop analysis to be run on any file, project, or solution in Visual Studio without modifying the source code. Visual Studio 2010, 2012, 2013, 2015, 2017, and 2019 are supported by this extension.
2. The [StyleCop.MSBuild NuGet package](https://www.nuget.org/packages/StyleCop.MSBuild), which allows StyleCop analysis to be added to any .NET 4.0+ project without installing anything else on the system.

There is also a [ReSharper plugin](https://github.com/StyleCop/StyleCop.ReSharper) that can be added using ReSharper's Extension Manager.

## Considerations

While pull requests will continue to be accepted, it is unlikely that any major development will be done on this project. It is increasingly difficult and inefficient to maintain the custom C# parser used by StyleCop. The primary motivation for recent maintenance work was to allow developers who were already using StyleCop to upgrade to Visual Studio 2015 and C# 6.

The Roslyn-based [StyleCopAnalyzers](https://github.com/DotNetAnalyzers/StyleCopAnalyzers) project is recommended for developers who use only Visual Studio 2015 or later.

