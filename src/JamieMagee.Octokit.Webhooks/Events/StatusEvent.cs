namespace JamieMagee.Octokit.Webhooks.Events
{
    [WebhookEventType(WebhookEventType.Status)]
    public sealed record StatusEvent : WebhookEvent
    {
        // TODO: special case
    }
}
