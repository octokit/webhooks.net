namespace Octokit.Webhooks.Models.CheckRunEvent;

[PublicAPI]
public sealed record CheckRunPullRequestHead
{
    [JsonPropertyName("ref")]
    public required string Ref { get; init; }

    [JsonPropertyName("sha")]
    public required string Sha { get; init; }

    [JsonPropertyName("repo")]
    public required RepoRef Repo { get; init; }
}
