namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.Create)]
public sealed record CreateEvent : WebhookEvent
{
    [JsonPropertyName("ref")]
    public string Ref { get; init; } = null!;

    [JsonPropertyName("ref_type")]
    [JsonConverter(typeof(StringEnumConverter<RefType>))]
    public StringEnum<RefType> RefType { get; init; } = null!;

    [JsonPropertyName("master_branch")]
    public string MasterBranch { get; init; } = null!;

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("pusher_type")]
    public string PusherType { get; init; } = null!;
}
