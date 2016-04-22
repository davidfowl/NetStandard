# Netstandard Guide

[![Join the chat at https://gitter.im/davidfowl/NetStandard](https://badges.gitter.im/davidfowl/NetStandard.svg)](https://gitter.im/davidfowl/NetStandard?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

This is a work in progress and will change as we fix bugs in the product to improve the porting user experience. The target audience for this is package authors. It assumes that you have built and published a NuGet package before.

## What is it?

Netstandard is the next step after Portable Class Libraries. Please read [the full Netstandard document](https://github.com/dotnet/corefx/blob/master/Documentation/architecture/net-platform-standard.md) for more information.

## Who is this for?

Moving to Netstandard is the way to go, going forward, to maximize reusability of your code. Here are a few situations you may find yourself in:

- [I already have a PCL csproj and I want to move to netstandard.](PclToNetStandard.md)
- [I already have a PCL csproj and I'm willing to change my current project system and build to use the new xproj project system.](XProjNetStandard.md)
- [I'm starting from scratch and I want to support netstandard.](XProjNetStandard.md)
- [I'm migrating an RC1 DNX project to an RC2 .NET CLI project.](RC1ToRC2.md)
- [I'm starting from my .NET Framework library and I want to go to netstandard.](NETFrameworkToNetStandard.md)

## Mapping .NET Standard versions to platforms

[Explaination using C# interfaces](https://github.com/davidfowl/NetStandard/blob/master/platforms.cs)

| Target Platform Name | Alias |  |  |  |  |  | |
| :---------- | :--------- |:--------- |:--------- |:--------- |:--------- |:--------- |:--------- |
|.NET Platform Standard | netstandard | 1.0 | 1.1 | 1.2 | 1.3 | 1.4 | 1.5 |
|.NET Core|netcoreapp|&rarr;|&rarr;|&rarr;|&rarr;|&rarr;|1.0|
|.NET Framework|net|&rarr;|&rarr;|&rarr;|&rarr;|&rarr;|4.6.2|
|||&rarr;|&rarr;|&rarr;|&rarr;|4.6.1||
|||&rarr;|&rarr;|&rarr;|4.6|||
|||&rarr;|&rarr;|4.5.2||||
|||&rarr;|&rarr;|4.5.1||||
|||&rarr;|4.5|||||
|Universal Windows Platform|uap|&rarr;|&rarr;|&rarr;|&rarr;|10.0||
|Windows|win|&rarr;|&rarr;|8.1||||
|||&rarr;|8.0|||||
|Windows Phone|wpa|&rarr;|&rarr;|8.1||||
|Windows Phone Silverlight|wp|8.1||||||
|||8.0||||||
|Mono/Xamarin Platforms||&rarr;|&rarr;|&rarr;|&rarr;|&rarr;|*|
|Mono||&rarr;|&rarr;|*|||||

## Considerations
- There are currently few or no packages using the `netstandard` target framework, because it was only recently created. This means that you may need to use a new feature called `project.json` [**imports**](https://github.com/aspnet/Home/wiki/Project.json-file) to bypass the NuGet compatiblity check when pulling in other packages as dependencies (see the compatiblity section of this document for more information).
- There are two NuGet experiences, `packages.config` and `project.json`. Most projects support `packages.config` today but NuGet is pushing people towards `project.json`. This is not the default experience in any other project except Windows Universal Applications and .NET Core projects.
- This process only works with Visual Studio 2015 Update 2 or later. It means when you convert your project, you'll only be able to use it in Visual Studio 2015, or from the command-line. Even though the library's project can only be used in Visual Studio 2015, but downstream consumers of the package will still be able to consume it from earlier versions of Visual Studio (see next point).
- It's possible to author packages that work in Visual Studio 2012 - 2015 but the NuGet client on 2012 and 2013 does not currently support the netstandard moniker. This doesn't mean things won't work, it just means you'll also need to include another dll in the package. The NuGet team is looking at down level support for this moniker.
- Windows Universal platform applications do not yet work with RC2 packages. This means that in order to build a NuGet package that targets all platforms , you'll need to have a different set of dependencies in your nuspec/project.json for `netcore50`.
- If you need to support .NET Framework 4.0 or lower, then you’ll have to support multiple target frameworks in your NuGet package. Netstandard supports .NET Framework 4.5 and higher.
- If you need to target multiple frameworks there are 2 approaches:
 - Use `.xproj` + `project.json`. This is a single project that can target multiple frameworks.
 - Use multiple `.csproj` files with different references

## Packages

Everything in Netstandard is represented as packages. The biggest benefit to this is that it no longer requires an installed SDK or Visual Studio to compile for a specific target framework. This is also beneficial for cross platform builds since the only thing you need is the .NET CLI tool chain.

## Required tools
- [Visual Studio 2015 Update 2](https://www.visualstudio.com/en-us/news/vs2015-update2-vs.aspx) or later
- [NuGet.exe 3.4.2-rc](https://dist.nuget.org/win-x86-commandline/v3.4.2-rc/nuget.exe) or later

