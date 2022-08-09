namespace Octokit.Webhooks.Models.StatusEvent;

[PublicAPI]
public sealed record CommitDetails
{
    [JsonPropertyName("author")]
    public Committer Author { get; init; } = null!;

    [JsonPropertyName("committer")]
    public Committer Committer { get; init; } = null!;

    [JsonPropertyName("message")]
    public string Message { get; init; } = null!;

    [JsonPropertyName("tree")]
    public CommitDetails Tree { get; init; } = null!;

    [JsonPropertyName("url")]
    public string Url { get; init; } = null!;

    [JsonPropertyName("comment_count")]
    public long CommentCount { get; init; }
}
