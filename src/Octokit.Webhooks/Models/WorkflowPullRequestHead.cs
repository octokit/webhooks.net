namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record WorkflowPullRequestHead
{
    [JsonPropertyName("ref")]
    public required string Ref { get; init; }

    [JsonPropertyName("sha")]
    public required string Sha { get; init; }

    [JsonPropertyName("repo")]
    public required RepoRef Repo { get; init; }
}
