namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.Delete)]
public sealed record DeleteEvent : WebhookEvent
{
    [JsonPropertyName("ref")]
    public required string Ref { get; init; }

    [JsonPropertyName("ref_type")]
    [JsonConverter(typeof(StringEnumConverter<RefType>))]
    public required StringEnum<RefType> RefType { get; init; }

    [JsonPropertyName("pusher_type")]
    public required string PusherType { get; init; }
}
