namespace JamieMagee.Octokit.Webhooks.Events
{
    [WebhookEventType(WebhookEventType.Ping)]
    public sealed record PingEvent : WebhookEvent
    {
        // TODO: special case
    }
}
