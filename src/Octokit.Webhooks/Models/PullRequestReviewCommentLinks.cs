namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record PullRequestReviewCommentLinks
{
    [JsonPropertyName("self")]
    public Link Self { get; init; } = null!;

    [JsonPropertyName("html")]
    public Link Html { get; init; } = null!;

    [JsonPropertyName("pull_request")]
    public Link PullRequest { get; init; } = null!;
}
