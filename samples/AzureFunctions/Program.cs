using AzureFunctions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Octokit.Webhooks;
using Octokit.Webhooks.AzureFunctions;

new HostBuilder()
    .ConfigureServices(collection =>
    {
        collection.AddSingleton<WebhookEventProcessor, MyWebhookEventProcessor>();
    })
    .ConfigureGitHubWebhooks()
    .ConfigureFunctionsWorkerDefaults()
    .Build()
    .Run();
