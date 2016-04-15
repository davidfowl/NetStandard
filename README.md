# Netstandard Guide

This is a work in progress and will change as we fix bugs in the product to improve the porting user experience.

## What is it?

[First read the uber document for background](https://github.com/dotnet/corefx/blob/master/Documentation/architecture/net-platform-standard.md).

TL;DR, it's the next step in the Portable Class Libraries ecosystem.

## Who is this for?

- [I already have a PCL csproj and I want to move to netstandard.](PclToNetStandard.md)
- [I'm starting from scratch and I want to support netstandard](XProjNetStandard.md) OR [I'm willing to change my current project system and build to use the new xproj project system.](XProjNetStandard.md)
- [I'm migrating an RC1 DNX project to an RC2 .NET CLI project](RC1ToRC2.md)
- [I'm starting from my .NET Framework library and I want to go to netstandard.](NETFrameworkToNetStandard.md)

## Considerations
- There are 2 NuGet experiences, `packages.config` and `project.json`. Most projects support `packages.config` today but NuGet is pushing people towards `project.json`. This is not the default experience in any other project except Windows Universal Applications and .NET Core projects.
- This process only works with the latest Visual Studio. It means when you convert your project, you'll only be able to use it in Visual Studio 2015.
- It's possible to author packages that work in Visual Studio 2012 - 2015 but the NuGet client on 2012 and 2013 does not currently support the netstandard moniker.
- Windows Universal platform applications do not yet work with RC2 packages, this means a nuget package that wants to target *all* platforms, you'll need to have a different set of dependencies in your nuspec/project.json for `netcore50`.
