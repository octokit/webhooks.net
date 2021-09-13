namespace JamieMagee.Octokit.Webhooks.Events
{
    [WebhookEventType(WebhookEventType.Public)]
    public sealed record PublicEvent : WebhookEvent
    {
        // TODO: special case
    }
}
