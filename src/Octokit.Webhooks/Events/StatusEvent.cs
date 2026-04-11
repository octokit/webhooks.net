namespace Octokit.Webhooks.Events;

using Octokit.Webhooks.Models.StatusEvent;

[PublicAPI]
[WebhookEventType(WebhookEventType.Status)]
public sealed record StatusEvent : WebhookEvent
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("sha")]
    public required string Sha { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("avatar_url")]
    public string? AvatarUrl { get; init; }

    [JsonPropertyName("target_url")]
    public string? TargetUrl { get; init; }

    [JsonPropertyName("context")]
    public required string Context { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("state")]
    [JsonConverter(typeof(StringEnumConverter<StatusState>))]
    public required StringEnum<StatusState> State { get; init; }

    [JsonPropertyName("commit")]
    public required Commit Commit { get; init; }

    [JsonPropertyName("branch")]
    public IReadOnlyList<Branch>? Branch { get; init; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset UpdatedAt { get; init; }
}
