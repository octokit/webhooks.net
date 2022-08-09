namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.Create)]
public sealed record CreateEvent : WebhookEvent
{
    [JsonPropertyName("ref")]
    public string Ref { get; init; } = null!;

    [JsonPropertyName("ref_type")]
    public RefType RefType { get; init; }

    [JsonPropertyName("master_branch")]
    public string MasterBranch { get; init; } = null!;

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("pusher_type")]
    public string PusherType { get; init; } = null!;
}
