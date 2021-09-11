namespace JamieMagee.Octokit.Webhooks
{
    using JamieMagee.Octokit.Webhooks.Events;
    using JamieMagee.Octokit.Webhooks.Events.PullRequest;

    public class MyWebhookProcessor : WebhookProcessor
    {
        protected override void ProcessPullRequestMessage(WebhookPayload payload, PullRequestEvent pullRequestEvent, PullRequestAction action) => base.ProcessPullRequestMessage(payload, pullRequestEvent, action);
    }
}
