# Contributing to ChilliSource.Core #

Your contributions to ChilliSource.Mobile are very welcome. Please grab and fix bugs and feature requests from the list of [issues](https://github.com/BlueChilli/ChilliSource.Core/issues)
To report a bug or feature request, please log a new issue [here](https://github.com/BlueChilli/ChilliSource.Core/issues).

## Contribution Guide ##

### Steps ###

To contribute, please follow these steps:

1. fork the repo (or sync your repo if you already have a fork)
2. create a topic branch in your forked repo
3. resolve issues on your fork's topic branch
4. ensure that your code complies with the [checklist](#checklist) below
5. run `./build.sh` and fix any errors or failed unit tests
6. submit a pull request to our `develop` branch

### Checklist ###

All pull requests are reviewed. Here is a checklist of requirements:

* ensure code follows the style guidelines described in [Coding Style](https://github.com/BlueChilli/ChilliSource.Core/blob/develop/doc/coding-style-dotnet.md)
* ensure changes don't break API compatibility (i.e. changing public types, members, parameters). Use overloads, new methods, or completely new classes/types instead.
* ensure that you have adequately commented your code, see [Comments](https://github.com/BlueChilli/ChilliSource.Core/blob/develop/doc/comments-dotnet.md)
* create tests as applicable to ensure proper test coverage
* if any of the code is not your own, provide [Attribution](https://github.com/BlueChilli/ChilliSource.Core/blob/develop/doc/attribution-dotnet.md)
* address PR feedback in an additional commit(s) rather than amending the existing commits
* give priority to the current style of the project or file you're changing even if it diverges from the general guidelines 
* do not send PRs for style changes
* do not submit "work in progress" PRs. A PR should only be submitted when it is considered ready for review and subsequent merging by the contributor




