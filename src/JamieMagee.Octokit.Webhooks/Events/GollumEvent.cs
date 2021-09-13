namespace JamieMagee.Octokit.Webhooks.Events
{
    [WebhookEventType(WebhookEventType.Gollum)]
    public sealed record GollumEvent : WebhookEvent
    {
        // TODO: special case
    }
}
