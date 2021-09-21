# How to contribute

Please note that this project is released with a [Contributor Code of Conduct](CODE_OF_CONDUCT.md).
By participating in this project you agree to abide by its terms.

We appreciate you taking the time to contribute to `Octokit.Webhooks`. Especially as a new contributor, you have a valuable perspective that we lost a long time ago: you will find things confusing and run into problems that no longer occur to us. Please share them with us, so we can make the experience for future contributors the best it could be.

Thank you 💖

## Creating an Issue

Before you create a new Issue:

1. Please make sure there is no [open issue](https://github.com/octokit/Octokit.Webhooks/issues) yet.
2. If it is a bug report, include the steps to reproduce the issue, and please create a reproducible test case on [dotnetfiddle.com](https://dotnetfiddle.net/).
3. If it is a feature request, please share the motivation for the new feature, what alternatives you tried, and how you would implement it.
4. Please include links to the corresponding GitHub documentation.

## Set up the repository locally

First, fork the repository.

Set up the repository locally. Replace `<your account name>` with the name of the account you forked to.

```shell
git clone https://github.com/<your account name>/Octokit.Webhooks.git
cd Octokit.Webhooks
dotnet tool restore
dotnet cake --target=Build
```

Run the tests before making changes to make sure the local setup is working as expected

```shell
dotnet cake --target=Test
```

## Submitting the Pull Request

- Create a new branch locally.
- Make your changes in that branch and push them to your fork
- Submit a pull request from your topic branch to the main branch on the `octokit/Octokit.Webhooks` repository.
- Be sure to tag any issues your pull request is taking care of / contributing to. Adding "Closes #123" to a pull request description will automatically close the issue once the pull request is merged in.