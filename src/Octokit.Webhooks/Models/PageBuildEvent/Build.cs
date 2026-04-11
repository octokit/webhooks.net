namespace Octokit.Webhooks.Models.PageBuildEvent;

[PublicAPI]
public sealed record Build
{
    [JsonPropertyName("url")]
    public required string Url { get; init; }

    [JsonPropertyName("status")]
    public required string Status { get; init; }

    [JsonPropertyName("error")]
    public required BuildError Error { get; init; }

    [JsonPropertyName("pusher")]
    public required User Pusher { get; init; }

    [JsonPropertyName("commit")]
    public required string Commit { get; init; }

    [JsonPropertyName("duration")]
    public long Duration { get; init; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset UpdatedAt { get; init; }
}
