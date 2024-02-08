# How to contribute to Rhythm.Drop

Thanks for reading this guide on how to contribute!

## Found an issue?

Create an issue outlining;

 * What you've found
 * The version it's in
 * Steps to replicate
 * Any additional resources like images, videos which might support

> [!TIP]
> Please note: this is issue tracker and not a support forum. Be sure to check the readme or wiki before reach out.
 
### Want to submit a fix?

After submitting an issue and discussing a potential solution with us there may be an opportunity to submit a fix. We operate on a pull request basis. In order to do this we recommend you take the following steps;

 1. Create a fork of the Rhythm.Drop repo on your github account
 2. Clone the fork locally
 3. Begin making a change locally
 4. Run tests in your IDE's Test Explorer before committing
 5. Commit little and often
 6. Run a local build and test against a local project before pushing to remote
 7. Submit a pull request

#### Running a local build

The following is a powershell script which will create a local packages. 

You will need to setup your IDE to support a local NuGet feed or include these packages in the project some other way.

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

## Have a new feature request?

Raise a ticket and we'll review your request. It is always best to discuss new features first rather diving into a PR. This way we can discuss if it's a right fit for Rhythm.Drop.
