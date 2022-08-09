namespace Octokit.Webhooks.Events;

using Octokit.Webhooks.Models.RepositoryImportEvent;

[PublicAPI]
[WebhookEventType(WebhookEventType.RepositoryImport)]
public sealed record RepositoryImportEvent : WebhookEvent
{
    [JsonPropertyName("status")]
    public Status Status { get; init; }
}
