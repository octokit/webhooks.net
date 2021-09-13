namespace JamieMagee.Octokit.Webhooks.Events
{
    [WebhookEventType(WebhookEventType.TeamAdd)]
    public sealed record TeamAddEvent : WebhookEvent
    {
        // TODO: special case
    }
}
