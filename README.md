# Octokit.Webhooks

[![GitHub Workflow Status](https://img.shields.io/github/actions/workflow/status/octokit/webhooks.net/build.yml?branch=main&style=for-the-badge)](https://github.com/octokit/webhooks.net/actions/workflows/build.yml?query=branch%3Amain)
[![Octokit.Webhooks NuGet Package Version](https://img.shields.io/nuget/v/Octokit.Webhooks?style=for-the-badge)](https://www.nuget.org/packages/Octokit.Webhooks/)
[![Octokit.Webhooks NuGet Package Downloads](https://img.shields.io/nuget/dt/Octokit.Webhooks?style=for-the-badge)](https://www.nuget.org/packages/Octokit.Webhooks/)
[![OpenSSF Scorecard](https://img.shields.io/ossf-scorecard/github.com/octokit/webhooks.net?style=for-the-badge)](https://scorecard.dev/viewer/?uri=github.com/octokit/webhooks.net)

Libraries to handle GitHub Webhooks in .NET applications.

## Usage

### ASP.NET Core

1. `dotnet add package Octokit.Webhooks.AspNetCore`
2. Create a class that derives from `WebhookEventProcessor` and override any of the virtual methods to handle webhooks from GitHub. For example, to handle Pull Request webhooks:

    ```C#
    public sealed class MyWebhookEventProcessor : WebhookEventProcessor
    {
        protected override ValueTask ProcessPullRequestWebhookAsync(
            WebhookHeaders headers,
            PullRequestEvent pullRequestEvent,
            PullRequestAction action,
            CancellationToken cancellationToken = default)
        {
            ...
        }
    }
    ```

3. Register your implementation of `WebhookEventProcessor`:

    ```C#
    builder.Services.AddSingleton<WebhookEventProcessor, MyWebhookEventProcessor>();
    ```

4. Map the webhook endpoint:

    ```C#
    app.UseEndpoints(endpoints =>
    {
        ...
        endpoints.MapGitHubWebhooks();
        ...
    });
    ```

`MapGitHubWebhooks()` takes two optional parameters:

* `path`. Defaults to `/api/github/webhooks`, the URL of the endpoint to use for GitHub.
* `secret`. The secret you have configured in GitHub, if you have set this up.

### Azure Functions

**NOTE**: Support is only provided for [isolated process Azure Functions](https://learn.microsoft.com/azure/azure-functions/dotnet-isolated-process-guide).

1. `dotnet add package Octokit.Webhooks.AzureFunctions`
2. Create a class that derives from `WebhookEventProcessor` and override any of the virtual methods to handle webhooks from GitHub. For example, to handle Pull Request webhooks:

    ```C#
    public sealed class MyWebhookEventProcessor : WebhookEventProcessor
    {
        protected override ValueTask ProcessPullRequestWebhookAsync(
            WebhookHeaders headers,
            PullRequestEvent pullRequestEvent,
            PullRequestAction action,
            CancellationToken cancellationToken = default)
        {
            ...
        }
    }
    ```

3. Register your implementation of `WebhookEventProcessor`:

    ```C#
    .ConfigureServices(collection =>
    {
        ...
        collection.AddSingleton<WebhookEventProcessor, MyWebhookEventProcessor>();
        ...
    })
    ```

4. Configure the webhook function:

    ```C#
    new HostBuilder()
    ...
    .ConfigureGitHubWebhooks()
    ...
    .Build();
    ```

`ConfigureGitHubWebhooks()` either takes an optional parameter:

* `secret`. The secret you have configured in GitHub, if you have set this up.

or:

* `configure`. A function that takes an IConfiguration instance and expects the secret you have configured in GitHub in return.

The function is available on the `/api/github/webhooks` endpoint.

## Thanks

- [octokit/webhooks](https://github.com/octokit/webhooks)
- [terrajobst/Terrajobst.GitHubEvents](https://github.com/terrajobst/Terrajobst.GitHubEvents)
- [Dotnet-Boxed/Templates](https://github.com/Dotnet-Boxed/Templates)

## License

All packages in this repository are licensed under [the MIT license](https://opensource.org/licenses/MIT).
