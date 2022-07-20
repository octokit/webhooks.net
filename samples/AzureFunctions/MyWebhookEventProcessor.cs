namespace AzureFunctions;

using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Octokit.Webhooks;
using Octokit.Webhooks.Events;
using Octokit.Webhooks.Events.PullRequest;

public class MyWebhookEventProcessor : WebhookEventProcessor
{
    private readonly ILogger<MyWebhookEventProcessor> logger;

    public MyWebhookEventProcessor(ILogger<MyWebhookEventProcessor> logger)
    {
        this.logger = logger;
    }

    protected override async Task ProcessPullRequestWebhookAsync(WebhookHeaders headers, PullRequestEvent pullRequestEvent, PullRequestAction action)
    {
        switch (action)
        {
            case PullRequestActionValue.Opened:
                this.logger.LogInformation("pull request opened");
                await Task.Delay(1000);
                break;
            default:
                this.logger.LogInformation("Some other pull request event");
                await Task.Delay(1000);
                break;
        }
    }
}
