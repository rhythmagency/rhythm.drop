# Maintainers Guide to Rhythm.Drop

The following guide is intended to maintainers of this repo. If you're not a maintainer check the [contributors guide](contributing-contributors.md).

## Creating new releases

The following assumes you have tested [a local build](BUILD.md) and merged all changes into the main branch ready for the next release of Rhythm.Drop.

> [!Warning]
> Do not proceed if you have no run unit test or ensured what you are able to commit will cause a build failure.

Great. Now we have that over and done with it. Let's create a new release!

### Step 1: Tagging the release
Create a new tag locally. Tags follow the following format `v{3 part-sematic version number}(-optional NuGet accepted suffix)`. Tags **must** start with the a lower case _v_.

✅Valid examples include;

 * v1.0.0-beta1
 * v1.0.0

❌ Invalid examples include;

* 1.0.0
* v1
* v1.0
* v1.0.0-

### Step 2: push tag to remote

Once the valid tag has been pushed to remote it will kick off a build action follow this build action and wait for it complete.

This will automatically push a release to NuGet for the tag version. The NuGet version will be the tag name without the _v_ prefix.

### Step 3: create a new release

Now the package is pushed to NuGet we're ready to create a new release in GitHub.

 1. Select the new tag
 2. Set the title of the release to be the same as the tag. (e.g. v1.0.0)
 3. Add release notes letting users generally what has changed in this version
 4. If you are creating a release for work by other people be sure to save this release as a draft and has it reviewed by others
 5. If this release was supported by other PRs list these PRs in the notes
 6. If this is a pre-release build check the pre-release option. This is used for releases with a suffix like beta, alpha or rc)
 7. Once complete publish the release

## General release guidelines

### Breaking changes

Consider carefully if the code you are releasing has any breaking changes and whether a new major version should be created. Always document breaking changes in release notes.

### Pre-releases

We generally do not release too many pre-release version. Instead choosing to fix with patch or minor version. 

As the maintainers team is small ideally releasing less versions that are more thought out would be the ideal path.
