namespace Octokit.Webhooks.Models;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
public sealed record SimpleCommit
{
    [JsonPropertyName("id")]
    public string Id { get; init; } = null!;

    [JsonPropertyName("tree_id")]
    public string TreeId { get; init; } = null!;

    [JsonPropertyName("message")]
    public string Message { get; init; } = null!;

    [JsonPropertyName("timestamp")]
    public string Timestamp { get; init; } = null!;

    [JsonPropertyName("author")]
    public Committer Author { get; init; } = null!;

    [JsonPropertyName("committer")]
    public Committer Committer { get; init; } = null!;
}
