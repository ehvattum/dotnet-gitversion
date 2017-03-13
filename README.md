msbuild-dotnet-gitversion - Simple git versioning for dotnet cli
========================================================

**msbuild-dotnet-gitversion** is a simple tool for stamping the `VersionPrefix` element in the dotnet core .csproj projects, using [GitVersion](https://github.com/GitTools/GitVersion) for generating the version number.

I have not bothered to create a proper integration at this point.

## Usage
* `dotnet publish -c release -o {where ever you want it, possibly as a contained lib}`
* create a simple PreBuildEvent like : `<PreBuildEvent>dotnet my-chosen-destination\dotnet-msbuild-gitversion.dll</PreBuildEvent>` that uses the `dotnet` cli.

Heavily based on https://github.com/ah-/dotnet-gitversion from Andreas Heider