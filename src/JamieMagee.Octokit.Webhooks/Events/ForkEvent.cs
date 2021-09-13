namespace JamieMagee.Octokit.Webhooks.Events
{
    [WebhookEventType(WebhookEventType.Fork)]
    public sealed record ForkEvent : WebhookEvent
    {
        // TODO: special case
    }
}
