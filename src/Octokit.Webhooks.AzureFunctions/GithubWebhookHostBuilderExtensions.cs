namespace Octokit.Webhooks.AzureFunctions;

using System;
using Microsoft.Extensions.Configuration;
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
            services.AddOptions<GitHubWebhooksOptions>().Configure(options => options.Secret = secret));

    /// <summary>
    /// Configures GitHub webhook function.
    /// </summary>
    /// <param name="hostBuilder"><see cref="IHostBuilder" /> instance.</param>
    /// <param name="configure">A function that takes an <see cref="IConfiguration" /> instance and expects the secret you have configured in GitHub in return.</param>
    /// <returns>Returns <see cref="IHostBuilder" /> instance.</returns>
    public static IHostBuilder ConfigureGitHubWebhooks(this IHostBuilder hostBuilder, Func<IConfiguration, string> configure)
    {
        ArgumentNullException.ThrowIfNull(configure);

        return hostBuilder.ConfigureServices((context, services) =>
            services.AddOptions<GitHubWebhooksOptions>().Configure(options => options.Secret = configure(context.Configuration)));
    }

    /// <summary>
    /// Configures GitHub webhook function.
    /// </summary>
    /// <param name="builder"><see cref="IHostApplicationBuilder" /> instance.</param>
    /// <param name="secret">The secret you have configured in GitHub, if you have set this up.</param>
    /// <returns>Returns <see cref="IHostApplicationBuilder" /> instance.</returns>
    public static IHostApplicationBuilder ConfigureGitHubWebhooks(this IHostApplicationBuilder builder, string? secret = null)
    {
        builder.Services.AddOptions<GitHubWebhooksOptions>().Configure(options => options.Secret = secret);
        return builder;
    }

    /// <summary>
    /// Configures GitHub webhook function.
    /// </summary>
    /// <param name="builder"><see cref="IHostApplicationBuilder" /> instance.</param>
    /// <param name="configure">A function that takes an <see cref="IConfiguration" /> instance and expects the secret you have configured in GitHub in return.</param>
    /// <returns>Returns <see cref="IHostApplicationBuilder" /> instance.</returns>
    public static IHostApplicationBuilder ConfigureGitHubWebhooks(this IHostApplicationBuilder builder, Func<IConfiguration, string> configure)
    {
        ArgumentNullException.ThrowIfNull(configure);

        builder.Services.AddOptions<GitHubWebhooksOptions>().Configure(options => options.Secret = configure(builder.Configuration));
        return builder;
    }
}
