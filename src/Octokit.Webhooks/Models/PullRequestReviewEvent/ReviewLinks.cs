namespace Octokit.Webhooks.Models.PullRequestReviewEvent;

[PublicAPI]
public sealed record ReviewLinks
{
    [JsonPropertyName("html")]
    public required Link Html { get; init; }

    [JsonPropertyName("pull_request")]
    public required Link PullRequest { get; init; }
}
