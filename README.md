# Netstandard Guide

This is a work in progress and will change as we fix bugs in the product to improve the porting user experience. The target auidence for this is package authors. It assumes that you have built and pubished a nuget package before.

## What is it?

[First read the uber document for background](https://github.com/dotnet/corefx/blob/master/Documentation/architecture/net-platform-standard.md).

TL;DR, it's the next step in the Portable Class Libraries ecosystem.

## Who is this for?

- [I already have a PCL csproj and I want to move to netstandard.](PclToNetStandard.md)
- [I'm starting from scratch and I want to support netstandard.](XProjNetStandard.md) OR [I'm willing to change my current project system and build to use the new xproj project system.](XProjNetStandard.md)
- [I'm migrating an RC1 DNX project to an RC2 .NET CLI project.](RC1ToRC2.md)
- [I'm starting from my .NET Framework library and I want to go to netstandard.](NETFrameworkToNetStandard.md)

## Considerations
- There are no packages that exist with the netstandard target framework. This is because we it was created only a few months ago. This means that you may need to use a new feature called `project.json` **imports** to bypass the NuGet compatiblity check when pulling in other packages as dependencies (see the compatiblity section of this document for more information).
- There are 2 NuGet experiences, `packages.config` and `project.json`. Most projects support `packages.config` today but NuGet is pushing people towards `project.json`. This is not the default experience in any other project except Windows Universal Applications and .NET Core projects.
- This process only works with the latest Visual Studio. It means when you convert your project, you'll only be able to use it in Visual Studio 2015.
- It's possible to author packages that work in Visual Studio 2012 - 2015 but the NuGet client on 2012 and 2013 does not currently support the netstandard moniker. This doesn't mean things won't work, it just means you'll also need to include another dll in the package. The NuGet team is looking at down level support for this moniker.
- Windows Universal platform applications do not yet work with RC2 packages, this means a nuget package that wants to target *all* platforms, you'll need to have a different set of dependencies in your nuspec/project.json for `netcore50`.
- If you need to target multiple frameworks there are 2 approaches:
 - Use `.xproj` + `project.json`. This is a single project that can target multiple frameworks.
 - Use multiple `.csproj` files with different references

## Packages

Everything is represented as packages. The biggest benefit to this is that it no longer requires an installed SDK or Visual Studio to compile for a specific target framework. This is also beneficial for cross platform builds since the only thing you need is the .NET CLI tool chain.

## Tools of the trade
- [Visual Studio 2015 Update 2](https://www.visualstudio.com/en-us/news/vs2015-update2-vs.aspx)
 - Make sure you have the latest version of NuGet >= 3.4
- [NuGet.exe 3.4.2-rc](https://dist.nuget.org/win-x86-commandline/v3.4.2-rc/nuget.exe)

