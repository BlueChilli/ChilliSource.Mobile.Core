# Contributing to ChilliSource #

Your contributions to ChilliSource are very welcome. Please grab and fix bugs and feature requests from the list of issues.
To report a bug or feature request, please log a new issue.

## Contribution Guide ##

### Steps ###

To contribute, please follow these steps:

1. fork the repo
2. create a topic branch in your forked repo
3. resolve issues on your fork's topic branch
4. ensure that your code complies with the [checklist](#checklist) below
5. run `./build.sh` and fix any errors or failed unit tests
6. submit a pull request to our `develop` branch

### Checklist ###

All pull requests are reviewed. Here is a checklist of requirements:

* ensure code follows the style guidelines described in [Coding Style](doc/coding-style.md)
* ensure changes don't break API compatibility (i.e. changing public types, members, parameters). Use overloads, new methods, or completely new classes/types instead.
* ensure that you have adequately commented your code, see [Commenting](#commenting) below
* create tests as applicable to ensure proper test coverage
* if any of the code is not your own, provide [Attribution](doc/attribution.md)
* address PR feedback in an additional commit(s) rather than amending the existing commits
* give priority to the current style of the project or file you're changing even if it diverges from the general guidelines 
* do not send PRs for style changes
* do not submit "work in progress" PRs. A PR should only be submitted when it is considered ready for review and subsequent merging by the contributor

### Commenting ###

* add a summary comment for each public type or method that you are adding
* where relevant comments should cover the purpose, usage, expected and hidden behaviours, and any other important considerations.	
* comment complex internal code
* prefer explaining the 'why' instead of the 'what' of the code
* comment default values of properties


