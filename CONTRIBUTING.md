# Contributing to ChilliSource #

Your contributions to ChilliSource are very welcome. Please grab and fix bugs and feature requests from the list of issues.
To report a bug or feature request, please log a new issue.

## Contribution Guide ##

ChilliSource is using the [GitFlow](https://datasift.github.io/gitflow/IntroducingGitFlow.html) branching model.

To contribute, please follow these steps:

1. fork the repo
3. resolve issues on the `develop` branch or create a feature branch if necessary
4. write unit tests as applicable to ensure proper test coverage
4. run `./build.sh` and fix any errors or failed unit tests
5. rebase your branch onto the latest version of the `develop` branch and merge any conflicts. Please refer to [this guide](https://github.com/edx/edx-platform/wiki/How-to-Rebase-a-Pull-Request) if you are new to git.
6. submit a pull request

All pull requests are reviewed. Here is a checklist of requirements:

* ensure code follows the style guidelines described in [Coding Style](doc/coding-style.md)
* ensure changes don't break compatibility with the public contract (i.e. changing public types, members, parameters). Use overloads, new methods, or completely new classes/types instead.
* ensure that you have adequately commented your code, see [Commenting](#commenting) below
* if any of the code is not your own, provide [Attribution](doc/attribution.md)
* follow commit message format outlined in [Commit Messages](#commit-messages) below
* link fixed issues in the commit message using `fixes #<issue number>`, see [Commit Messages](#commit-messages) below
* address PR feedback in an additional commit(s) rather than amending the existing commits
* give priority to the current style of the project or file you're changing even if it diverges from the general guidelines 
* do not send PRs for style changes
* do not submit "work in progress" PRs. A PR should only be submitted when it is considered ready for review and subsequent merging by the contributor

### Commenting ###

* add a summary comment for each public type
* add a summary comment for each public method, with the only exception being extremely trivial methods where the comment would not add any value
* comment public methods that are non-trivial to cover where relevant the purpose, usage, expected and hidden behaviours, and any other important considerations.	
* use comments to describe the intention and purpose of complex internal code
* consider refactoring internal code that requires comments to make the code more clear
* consider commenting complex business rules
* prefer explaining the 'why' instead of the 'what' of the code
* comment default values of properties
* always delete code instead of commenting out code

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

