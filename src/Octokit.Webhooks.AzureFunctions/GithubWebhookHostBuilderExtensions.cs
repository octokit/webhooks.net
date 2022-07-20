namespace Octokit.Webhooks.AzureFunctions;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public static class GithubWebhookHostBuilderExtensions
{
    /// <summary>
    /// Configures GitHub webhook function.
    /// </summary>
    /// <param name="hostBuilder"><see cref="IHostBuilder" /> instance.</param>
    /// <param name="secret">The secret you have configured in GitHub, if you have set this up.</param>
    /// <returns>Returns <see cref="IHostBuilder" /> instance.</returns>
    public static IHostBuilder ConfigureGitHubWebhooks(this IHostBuilder hostBuilder, string? secret = null) =>
        hostBuilder.ConfigureServices(services =>
            services.AddOptions<GitHubWebhooksOptions>().Configure(options => { options.Secret = secret; }));
}
