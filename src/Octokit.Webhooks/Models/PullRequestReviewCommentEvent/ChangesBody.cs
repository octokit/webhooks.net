namespace Octokit.Webhooks.Models.PullRequestReviewCommentEvent;

[PublicAPI]
public sealed record ChangesBody
{
    [JsonPropertyName("from")]
    public required string From { get; init; }
}
