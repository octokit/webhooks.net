namespace Octokit.Webhooks.Models;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
public sealed record PullRequestAutoMerge
{
    [JsonPropertyName("enabled_by")]
    public User EnabledBy { get; init; } = null!;

    [JsonPropertyName("merge_method")]
    public string MergeMethod { get; init; } = null!;

    [JsonPropertyName("commit_title")]
    public string CommitTitle { get; init; } = null!;

    [JsonPropertyName("commit_message")]
    public string CommitMessage { get; init; } = null!;
}
