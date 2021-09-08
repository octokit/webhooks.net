namespace JamieMagee.Octokit.Webhooks.Extensions
{
    using Events;

    public static class WebhookExtensions
    {
        public static bool IsPullRequestEvent(WebhookEvent webhookEvent) => webhookEvent is PullRequestEvent;
    }
}
