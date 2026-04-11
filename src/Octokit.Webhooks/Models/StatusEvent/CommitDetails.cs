namespace Octokit.Webhooks.Models.StatusEvent;

[PublicAPI]
public sealed record CommitDetails
{
    [JsonPropertyName("author")]
    public Committer? Author { get; init; }

    [JsonPropertyName("committer")]
    public Committer? Committer { get; init; }

    [JsonPropertyName("message")]
    public string? Message { get; init; }

    [JsonPropertyName("tree")]
    public CommitDetails? Tree { get; init; }

    [JsonPropertyName("url")]
    public required string Url { get; init; }

    [JsonPropertyName("comment_count")]
    public long CommentCount { get; init; }
}
