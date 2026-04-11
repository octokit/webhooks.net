namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record SimpleCommit
{
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    [JsonPropertyName("tree_id")]
    public required string TreeId { get; init; }

    [JsonPropertyName("message")]
    public required string Message { get; init; }

    [JsonPropertyName("timestamp")]
    public required string Timestamp { get; init; }

    [JsonPropertyName("author")]
    public required Committer Author { get; init; }

    [JsonPropertyName("committer")]
    public required Committer Committer { get; init; }
}
