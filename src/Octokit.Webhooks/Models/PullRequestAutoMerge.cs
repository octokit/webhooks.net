namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record PullRequestAutoMerge
{
    [JsonPropertyName("enabled_by")]
    public required User EnabledBy { get; init; }

    [JsonPropertyName("merge_method")]
    public required string MergeMethod { get; init; }

    [JsonPropertyName("commit_title")]
    public required string CommitTitle { get; init; }

    [JsonPropertyName("commit_message")]
    public required string CommitMessage { get; init; }
}
