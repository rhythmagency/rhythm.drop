# Running a local build

The following is a powershell script which will create a local packages. 

You will need to setup your IDE to support a local NuGet feed or include these packages in the project some other way.

> [!TIP]
> Generally it is a good idea to set the NuGet package version to have a `-beta{number}` or `-alpha{number}` suffix so as not to get a conflict with released versions on a remote NuGet feed.

```powershell
# This script is intended to be placed and run outside of the git repo so it is not accidentally committed.
# To run this script you will need dotnet-cli (v8) installed
$CONFIG = 'Release';
$IN_FOLDER = 'C:\Path\To\Rhythm.Drop\Repo\Root'
$OUT_FOLDER = 'C:\Path\To\Your\Local\nuget';
# NuGet package version (e.g. 6.0.0-beta1)
$VERSION = '5.0.0';

$START_FOLDER = (get-location).path;

Set-Location $IN_FOLDER;

# Restore dependencies
dotnet restore ./src/Rhythm.Drop.sln

# Test Rhythm.Drop.Builders
dotnet test ./tests/Rhythm.Drop.Builders.Tests/Rhythm.Drop.Builders.Tests.csproj

# Test Rhythm.Drop.Web
dotnet test ./tests/Rhythm.Drop.Web.Tests/Rhythm.Drop.Web.Tests.csproj

# Build Rhythm.Drop.Models
dotnet pack ./src/Rhythm.Drop.Models/Rhythm.Drop.Models.csproj --no-restore -c ${CONFIG} --output ${OUT_FOLDER} /p:version=${VERSION}

# Build Rhythm.Drop.Infrastructure
dotnet pack ./src/Rhythm.Drop.Infrastructure/Rhythm.Drop.Infrastructure.csproj --no-restore -c ${CONFIG} --output ${OUT_FOLDER} /p:version=${VERSION}

# Build Rhythm.Drop.Builders
dotnet pack ./src/Rhythm.Drop.Builders/Rhythm.Drop.Builders.csproj --no-restore -c ${CONFIG} --output ${OUT_FOLDER} /p:version=${VERSION}

# Build Rhythm.Drop.Web.Infrastructure
dotnet pack ./src/Rhythm.Drop.Web.Infrastructure/Rhythm.Drop.Web.Infrastructure.csproj --no-restore -c ${CONFIG} --output ${OUT_FOLDER} /p:version=${VERSION}

# Build Rhythm.Drop.Web
dotnet pack ./src/Rhythm.Drop.Web/Rhythm.Drop.Web.csproj --no-restore -c ${CONFIG} --output ${OUT_FOLDER} /p:version=${VERSION}

# Build Rhythm.Drop
dotnet pack ./src/Rhythm.Drop/Rhythm.Drop.csproj --no-restore -c ${CONFIG} --output ${OUT_FOLDER} /p:version=${VERSION}

Set-Location $START_FOLDER;
```
