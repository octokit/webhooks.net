namespace Octokit.Webhooks.Models.PullRequestEvent;

[PublicAPI]
public sealed record PullRequestBase
{
    [JsonPropertyName("label")]
    public required string Label { get; init; }

    [JsonPropertyName("ref")]
    public required string Ref { get; init; }

    [JsonPropertyName("sha")]
    public required string Sha { get; init; }

    [JsonPropertyName("user")]
    public required User User { get; init; }

    [JsonPropertyName("repo")]
    public required Repository Repo { get; init; }
}
