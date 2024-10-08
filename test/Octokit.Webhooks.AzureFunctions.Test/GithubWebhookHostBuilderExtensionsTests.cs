namespace Octokit.Webhooks.AzureFunctions.Test;

using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

public class GithubWebhookHostBuilderExtensionsTests
{
    [Fact]
    public void CanConfigureSecretUsingPlainText()
    {
        // Arrange
        var mockHostBuilder = new Mock<IHostBuilder>();
        var services = new ServiceCollection();
        var testSecret = "test-secret";

        mockHostBuilder
            .Setup(hb => hb.ConfigureServices(It.IsAny<Action<HostBuilderContext, IServiceCollection>>()))
            .Callback<Action<HostBuilderContext, IServiceCollection>>((action) =>
            {
                var context = new HostBuilderContext(new Dictionary<object, object>());
                action(context, services);
            })
            .Returns(mockHostBuilder.Object);

        // Act
        mockHostBuilder.Object.ConfigureGitHubWebhooks(testSecret);

        // Assert
        var serviceProvider = services.BuildServiceProvider();
        var options = serviceProvider.GetRequiredService<IOptions<GitHubWebhooksOptions>>().Value;
        Assert.Equal(testSecret, options.Secret);
    }

    [Fact]
    public void CanConfigureSecretUsingConfigurationInstance()
    {
        // Arrange
        var mockHostBuilder = new Mock<IHostBuilder>();
        var services = new ServiceCollection();
        var testSecret = "test-secret";
        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["GitHubSecret"] = testSecret,
            })
            .Build();

        mockHostBuilder
            .Setup(hb => hb.ConfigureServices(It.IsAny<Action<HostBuilderContext, IServiceCollection>>()))
            .Callback<Action<HostBuilderContext, IServiceCollection>>((action) =>
            {
                var context = new HostBuilderContext(new Dictionary<object, object>())
                {
                    Configuration = configuration,
                };
                action(context, services);
            })
            .Returns(mockHostBuilder.Object);

        static string Configure(IConfiguration config) => config.GetValue<string>("GitHubSecret")
            ?? throw new ArgumentNullException();

        // Act
        mockHostBuilder.Object.ConfigureGitHubWebhooks(Configure);

        // Assert
        var serviceProvider = services.BuildServiceProvider();
        var options = serviceProvider.GetRequiredService<IOptions<GitHubWebhooksOptions>>().Value;
        Assert.Equal(testSecret, options.Secret);
    }
}
