namespace JamieMagee.Octokit.Webhooks.Events
{
    [WebhookEventType(WebhookEventType.Push)]
    public sealed record PushEvent : WebhookEvent
    {
        // TODO: special case
    }
}
