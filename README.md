# StyleCop

StyleCop analyses C# source code to enforce a set of style and consistency rules.

[![Gitter](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/StyleCop/StyleCop?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

## About this fork

This is an unofficial fork of the StyleCop project hosted at [CodePlex](http://stylecop.codeplex.com). The StyleCop project has been maintained by Andy Reeves for several years, but has been on [indefinite hiatus since March 2014](https://twitter.com/stylecopdev/status/448202371798433792), with the [last commit to the project](https://github.com/StyleCop/StyleCop/commit/d9577105fee871b9f49cd7e86858b4044b99b192) being on March 31, 2014. Attempts to contact Andy since then have failed, and the need to update the project to (at the very least) update the ReSharper plugin to work with later versions of ReSharper means that a fork is the only viable way forward.

## Roadmap

The immediate concerns of this GitHub project are to get the ReSharper plugin updated to the latest versions of ReSharper. What happens after that depends on the requests of the community.

## Development Requirements

[Visual Studio 2013](https://www.visualstudio.com/en-us/downloads/download-visual-studio-vs.aspx)  
[Visual Studio 2013 SDK](https://www.microsoft.com/download/details.aspx?id=40758)  
[WiX Toolset 3.5.2325.0](http://wix.codeplex.com/releases/view/60102)  
[JetBrains ReSharper 9.2](https://www.jetbrains.com/resharper/)  


* Right-click on your Windows Desktop and select New->Shortcut

* In the target box that appears, fill in "%windir%\system32\cmd.exe /k {YourDevFolder}\project\environment.cmd" where {YourDevFolder} is the root location of the folder where you placed the StyleCop source code.

* Set this shortcut to open the cmd prompt as administrator

* Click on this new shortcut to launch a StyleCop enlistment window. This should open up without errors.

* From your cmd window run VerifyBuild.cmd. This should complete without errors.

* In order to build/edit StyleCop properly in Visual Studio then Visual Studio must be launched from within this cmdwindow. From your cmd window type StyleCop.sln. This will launch Visual Studio and load the StyleCop solution.