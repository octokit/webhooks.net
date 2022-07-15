namespace Octokit.Webhooks.Events;

using Octokit.Webhooks.Models.RepositoryImportEvent;

[PublicAPI]
[WebhookEventType(WebhookEventType.RepositoryImport)]
public sealed record RepositoryImportEvent : WebhookEvent
{
    [JsonPropertyName("status")]
    [JsonConverter(typeof(StringEnumConverter<Status>))]
    public StringEnum<Status> Status { get; init; } = null!;
}
