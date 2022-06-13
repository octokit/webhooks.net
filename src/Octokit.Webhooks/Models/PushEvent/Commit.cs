namespace Octokit.Webhooks.Models.PushEvent;

using System.Collections.Generic;
using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
public sealed record Commit
{
    [JsonPropertyName("id")]
    public string Id { get; init; } = null!;

    [JsonPropertyName("tree_id")]
    public string TreeId { get; init; } = null!;

    [JsonPropertyName("distinct")]
    public bool Distinct { get; init; }

    [JsonPropertyName("message")]
    public string Message { get; init; } = null!;

    [JsonPropertyName("timestamp")]
    public string Timestamp { get; init; } = null!;

    [JsonPropertyName("url")]
    public string Url { get; init; } = null!;

    [JsonPropertyName("author")]
    public Committer Author { get; init; } = null!;

    [JsonPropertyName("committer")]
    public Committer Committer { get; init; } = null!;

    [JsonPropertyName("added")]
    public IEnumerable<string> Added { get; init; } = null!;

    [JsonPropertyName("modified")]
    public IEnumerable<string> Modified { get; init; } = null!;

    [JsonPropertyName("removed")]
    public IEnumerable<string> Removed { get; init; } = null!;
}