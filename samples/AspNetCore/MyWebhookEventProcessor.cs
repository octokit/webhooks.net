namespace AspNetCore;

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Octokit.Webhooks;
using Octokit.Webhooks.Events;
using Octokit.Webhooks.Events.PullRequest;

public class MyWebhookEventProcessor(ILogger<MyWebhookEventProcessor> logger) : WebhookEventProcessor
{
    protected override async Task ProcessPullRequestWebhookAsync(
        WebhookHeaders headers,
        PullRequestEvent pullRequestEvent,
        PullRequestAction action,
        CancellationToken cancellationToken = default)
    {
        switch (action)
        {
            case PullRequestActionValue.Opened:
                logger.LogInformation("pull request opened");
                await Task.Delay(1000, cancellationToken);
                break;
            default:
                logger.LogInformation("Some other pull request event");
                await Task.Delay(1000, cancellationToken);
                break;
        }
    }
}
