namespace Octokit.Webhooks.Models.CheckRunEvent;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
public sealed record CheckRunPullRequestBase
{
    [JsonPropertyName("ref")]
    public string Ref { get; init; } = null!;

    [JsonPropertyName("sha")]
    public string Sha { get; init; } = null!;

    [JsonPropertyName("repo")]
    public RepoRef Repo { get; init; } = null!;
}