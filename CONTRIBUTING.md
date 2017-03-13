# Contributing to ChilliSource #

Your contributions to ChilliSource are very welcome. Please grab and fix bugs and feature requests from the list of issues.
To report a bug or feature request, please log a new issue.

## Contribution Guide ##

ChilliSource is using the [GitFlow](https://datasift.github.io/gitflow/IntroducingGitFlow.html) branching model.

To contribute, please follow these steps:

1. fork the repo
2. create a local branch based off the `develop` branch
3. resolve an issue
4. write unit tests as applicable to ensure proper test coverage
4. run all unit tests
5. if all tests pass submit a pull request
6. rebase your branch onto the latest version of the `develop` branch. Please refer to [this guide](https://github.com/edx/edx-platform/wiki/How-to-Rebase-a-Pull-Request) if you are new to git.

All pull requests are reviewed. Here is a checklist of requirements:

* code follows the style guidelines described in [Coding Style](doc/coding-style.md)
* changes don't break compatibility with the public contract (i.e. changing public types, members, parameters). Use overloads, new methods, or completely new classes/types instead.
* do not send PRs for style changes
* give priority to the current style of the project or file you're changing even if it diverges from the general guidelines 
* do not submit "work in progress" PRs. A PR should only be submitted when it is considered ready for review and subsequent merging by the contributor
* each new file should include header with the license information, see [File Header](#file-headers) below
* if any of the code is not your own, provide [Attribution](doc/attribution.md)
* commit message should follow format outlined in [Commit Messages](#commit-messages) below
* fixed issues should be linked in the commit message using `fixes #<issue number>`, see [Commit Messages](#commit-messages) below
* address PR feedback in an additional commit(s) rather than ammending the existing commits

### Versioning ###

Major.Minor.Patch

Major = definite breaking change
Minor = not a change to api public contract, but internal change that could potentially affect functionality
Patch = no breaking changes

#### New Versions of Existing APIs ####

* use a name similar to the old API when creating new versions of an existing API
* prefer adding a suffix rather than a prefix to indicate a new version of an existing API

### Commit Messages ###

Please format commit messages as follows:

```
Summarise change in 50 characters or less

Provide more detail after the first line. Leave one blank line below the
summary and wrap all lines at 72 characters or less.

If the change fixes an issue, leave another blank line after the final
paragraph and indicate which issue is fixed in the specific format
below.

Fixes #*issue number*
```
