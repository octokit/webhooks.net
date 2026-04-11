namespace Octokit.Webhooks.Models.PushEvent;

[PublicAPI]
public sealed record Commit
{
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    [JsonPropertyName("tree_id")]
    public required string TreeId { get; init; }

    [JsonPropertyName("distinct")]
    public bool Distinct { get; init; }

    [JsonPropertyName("message")]
    public required string Message { get; init; }

    [JsonPropertyName("timestamp")]
    public required string Timestamp { get; init; }

    [JsonPropertyName("url")]
    public required string Url { get; init; }

    [JsonPropertyName("author")]
    public required Committer Author { get; init; }

    [JsonPropertyName("committer")]
    public required Committer Committer { get; init; }

    [JsonPropertyName("added")]
    public required IReadOnlyList<string> Added { get; init; }

    [JsonPropertyName("modified")]
    public required IReadOnlyList<string> Modified { get; init; }

    [JsonPropertyName("removed")]
    public required IReadOnlyList<string> Removed { get; init; }
}
