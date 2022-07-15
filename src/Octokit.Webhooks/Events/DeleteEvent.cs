namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.Delete)]
public sealed record DeleteEvent : WebhookEvent
{
    [JsonPropertyName("ref")]
    public string Ref { get; init; } = null!;

    [JsonPropertyName("ref_type")]
    [JsonConverter(typeof(StringEnumConverter<RefType>))]
    public StringEnum<RefType> RefType { get; init; } = null!;

    [JsonPropertyName("pusher_type")]
    public string PusherType { get; init; } = null!;
}
