namespace Octokit.Webhooks.Events;

using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Models;

[PublicAPI]
[WebhookEventType(WebhookEventType.Delete)]
public sealed record DeleteEvent : WebhookEvent
{
    [JsonPropertyName("ref")]
    public string Ref { get; init; } = null!;

    [JsonPropertyName("ref_type")]
    public RefType RefType { get; init; }

    [JsonPropertyName("pusher_type")]
    public string PusherType { get; init; } = null!;
}
