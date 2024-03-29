﻿# Contributing to Cricks API

First off, thank you for considering contributing to Cricks API. It's people like you that make Cricks API such a great tool.

## Where do I go from here?

If you've noticed a bug or have a feature request, make one! It's generally best if you get confirmation of your bug or approval for your feature request this way before starting to code.

## Fork & create a branch

If this is something you think you can fix, then fork Cricks API and create a branch with a descriptive name.

A good branch name would be (where issue #325 is the ticket you're working on):


## Get the test suite running

Make sure you're using the latest version of .NET. Then, install the development dependencies:


Run the test suite to ensure everything is working correctly:




## Implement your fix or feature

At this point, you're ready to make your changes! Feel free to ask for help; everyone is a beginner at first 😸



## Make a Pull Request

At this point, you should switch back to your master branch and make sure it's up to date with Cricks API's master branch:


Then update your feature branch from your local copy of master, and push it!


Finally, go to GitHub and [make a Pull Request](https://help.github.com/en/github/collaborating-with-issues-and-pull-requests/creating-a-pull-request) 🚀



## Keeping your Pull Request updated

If a maintainer asks you to "rebase" your PR, they're saying that a lot of code has changed, and that you need to update your branch so it's easier to merge.

To learn more about rebasing in Git, there are a lot of [good](https://git-scm.com/book/en/v2/Git-Branching-Rebasing) [resources](https://www.atlassian.com/git/tutorials/rewriting-history/git-rebase) but here's the suggested workflow:


## Merging a PR (maintainers only)

A PR can only be merged into master by a maintainer if:

- It is passing CI.
- It has been approved by at least one maintainer. If it was a maintainer who opened the PR, only an additional maintainer can approve it.
- It has no requested changes.
- It is up to date with current master.

Any maintainer is allowed to merge a PR if all of these conditions are met.
