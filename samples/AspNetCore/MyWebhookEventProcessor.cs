namespace AspNetCore
{
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

        protected override Task ProcessPullRequestWebhook(WebhookHeaders headers, PullRequestEvent pullRequestEvent, PullRequestAction action)
        {
            switch (action)
            {
                case PullRequestActionValue.Opened:
                    this.logger.LogInformation("pull request opened");
                    break;
                default:
                    this.logger.LogInformation("Some other pull request event");
                    break;
            }
            return Task.CompletedTask;
        }
    }
}
