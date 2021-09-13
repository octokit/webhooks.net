namespace AspNetCore
{
    using System.Text.Json;
    using JamieMagee.Octokit.Webhooks;
    using JamieMagee.Octokit.Webhooks.Events;
    using JamieMagee.Octokit.Webhooks.Events.PullRequest;
    using Microsoft.Extensions.Logging;

    public class MyWebhookProcessor : WebhookProcessor
    {
        private readonly ILogger<MyWebhookProcessor> logger;

        public MyWebhookProcessor(ILogger<MyWebhookProcessor> logger)
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
