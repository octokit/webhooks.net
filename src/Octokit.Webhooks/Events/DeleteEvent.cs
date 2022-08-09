namespace Octokit.Webhooks.Events;

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
