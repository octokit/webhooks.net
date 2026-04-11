namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record PullRequestReviewCommentLinks
{
    [JsonPropertyName("self")]
    public required Link Self { get; init; }

    [JsonPropertyName("html")]
    public required Link Html { get; init; }

    [JsonPropertyName("pull_request")]
    public required Link PullRequest { get; init; }
}
