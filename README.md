dotnet-msbuild-gitversion - Simple git versioning for dotnet cli
========================================================

**dotnet-msbuild-gitversion** is a simple tool for stamping the `VersionPrefix` element in the dotnet core .csproj projects, using [GitVersion](https://github.com/GitTools/GitVersion) for generating the version number.

I have not bothered to create a proper integration at this point.

## Usage
* `dotnet publish -c release -o {where ever you want it, possibly as a contained lib}`

* --create a simple PreBuildEvent like : `<PreBuildEvent>dotnet my-chosen-destination\dotnet-msbuild-gitversion.dll</PreBuildEvent>` that uses the `dotnet` cli.-- To make it work with cmd aswell, use a build target instead, that way, the SDK-implicit target is inported, and we can get nice things like the directory-variable below
*  ```xml
<Target Name="PreBuild" BeforeTargets="PreBuildEvent">
     <Exec Command="dotnet $(SolutionDir)lib\dotnet-msbuild-gitversion\dotnet-msbuild-gitversion.dll" />
 </Target>
```

Heavily based on https://github.com/ah-/dotnet-gitversion from Andreas Heider
