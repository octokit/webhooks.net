namespace JamieMagee.Octokit.Webhooks.Events
{
    [WebhookEventType(WebhookEventType.RepositoryImport)]
    public sealed record RepositoryImportEvent : WebhookEvent
    {
        // TODO: special case
    }
}
