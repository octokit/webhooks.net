namespace JamieMagee.Octokit.Webhooks.Events
{
    [WebhookEventType(WebhookEventType.Delete)]
    public abstract record DeleteEvent : WebhookEvent
    {
        // TODO: special case
    }
}
