namespace Octokit.Webhooks.Events;

using Octokit.Webhooks.Models.CodeScanningAlertEvent;

[PublicAPI]
[WebhookEventType(WebhookEventType.CodeScanningAlert)]
[JsonConverter(typeof(WebhookConverter<CodeScanningAlertEvent>))]
public abstract record CodeScanningAlertEvent : WebhookEvent
{
    [JsonPropertyName("alert")]
    public required Alert Alert { get; init; }

    [JsonPropertyName("ref")]
    public required string Ref { get; init; }

    [JsonPropertyName("commit_oid")]
    public required string CommitOid { get; init; }
}
