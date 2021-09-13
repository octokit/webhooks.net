namespace JamieMagee.Octokit.Webhooks.Events
{
    [WebhookEventType(WebhookEventType.PageBuild)]
    public sealed record PageBuildEvent : WebhookEvent
    {
        // TODO: special case
    }
}
