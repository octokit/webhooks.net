namespace JamieMagee.Octokit.Webhooks.Events
{
    [WebhookEventType(WebhookEventType.Create)]
    public sealed record CreateEvent : WebhookEvent
    {
        // TODO: special case
    }
}
