namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.Create)]
public sealed record CreateEvent : WebhookEvent
{
    [JsonPropertyName("ref")]
    public required string Ref { get; init; }

    [JsonPropertyName("ref_type")]
    [JsonConverter(typeof(StringEnumConverter<RefType>))]
    public required StringEnum<RefType> RefType { get; init; }

    [JsonPropertyName("master_branch")]
    public required string MasterBranch { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("pusher_type")]
    public required string PusherType { get; init; }
}
