namespace Octokit.Webhooks.Events;

using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Converter;
using Octokit.Webhooks.Models.CodeScanningAlertEvent;

[PublicAPI]
[WebhookEventType(WebhookEventType.CodeScanningAlert)]
[JsonConverter(typeof(WebhookConverter<CodeScanningAlertEvent>))]
public abstract record CodeScanningAlertEvent : WebhookEvent
{
    [JsonPropertyName("alert")]
    public Alert Alert { get; init; } = null!;

    [JsonPropertyName("ref")]
    public string Ref { get; init; } = null!;

    [JsonPropertyName("commit_oid")]
    public string CommitOid { get; init; } = null!;
}