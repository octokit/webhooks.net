namespace AspNetCore
{
    using JamieMagee.Octokit.Webhooks;
    using JamieMagee.Octokit.Webhooks.Events;
    using JamieMagee.Octokit.Webhooks.Events.PullRequest;
    using Microsoft.Extensions.Logging;

    public class MyWebhookEventProcessor : WebhookEventProcessor
    {
        private readonly ILogger<MyWebhookEventProcessor> logger;

        public MyWebhookEventProcessor(ILogger<MyWebhookEventProcessor> logger)
        {
            this.logger = logger;
        }

        protected override void ProcessPullRequestWebhook(WebhookHeaders headers, PullRequestEvent pullRequestEvent, PullRequestAction action)
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
        }
    }
}
