# JamieMagee.Octokit.Webhooks

![GitHub Workflow Status](https://img.shields.io/github/workflow/status/JamieMagee/Octokit.Webhooks/Build?style=for-the-badge)
![JamieMagee.Octokit.Webhooks NuGet Package Version](https://img.shields.io/nuget/v/Octokit.Webhooks?style=for-the-badge)
![JamieMagee.Octokit.Webhooks NuGet Package Downloads](https://img.shields.io/nuget/dt/Octokit.Webhooks?style=for-the-badge)
![Stability - Experimental](https://img.shields.io/badge/stability-experimental-orange?style=for-the-badge)

Libraries to handle GitHub Webhooks in .NET applications.

## Usage in ASP.NET Core

1. `dotnet add package JamieMagee.Octokit.Webhooks.AspNetCore`
2. Create a class that derives from `WebhookEventProcessor` and override any of the virtual methods to handle webhooks from GitHub. For example, to handle Pull Request webhooks:

    ```C#
    public sealed class MyWebhookEventProcessor : WebhookEventProcessor
    {
        protected override void ProcessPullRequestWebhook(WebhookHeaders headers, PullRequestEvent pullRequestEvent, PullRequestAction action) {
            ...
        }
    }
    ```

3. Modify your `ConfigureServices()` method to register an implementation for `GitHubEventProcessor`:

    ```C#
    public void ConfigureServices(IServiceCollection services)
    {
        ...
        services.AddSingleton<WebhookEventProcessor, MyWebhookEventProcessor>();
        ...
    }
    ```
4. Modify your `Configure()` method to map the webhook end point:

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

## Thanks

- [octokit/webhooks](https://github.com/octokit/webhooks)
- [terrajobst/Terrajobst.GitHubEvents](https://github.com/terrajobst/Terrajobst.GitHubEvents)
- [Dotnet-Boxed/Templates](https://github.com/Dotnet-Boxed/Templates)

## License

All packages in this repository are licensed under [the MIT license](https://opensource.org/licenses/MIT).
