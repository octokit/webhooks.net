namespace Octokit.Webhooks.Models.StatusEvent;

[PublicAPI]
public sealed record Commit
{
    [JsonPropertyName("sha")]
    public required string Sha { get; init; }

    [JsonPropertyName("node_id")]
    public required string NodeId { get; init; }

    [JsonPropertyName("commit")]
    public required CommitDetails CommitDetails { get; init; }

    [JsonPropertyName("url")]
    public required string Url { get; init; }

    [JsonPropertyName("html_url")]
    public required string HtmlUrl { get; init; }

    [JsonPropertyName("comments_url")]
    public required string CommentsUrl { get; init; }

    [JsonPropertyName("author")]
    public User? Author { get; init; }

    [JsonPropertyName("committer")]
    public User? Committer { get; init; }

    [JsonPropertyName("parents")]
    public required IReadOnlyList<CommitParent> Parents { get; init; }
}
