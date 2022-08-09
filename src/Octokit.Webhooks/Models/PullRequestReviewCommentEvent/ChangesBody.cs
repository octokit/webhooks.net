namespace Octokit.Webhooks.Models.PullRequestReviewCommentEvent;

[PublicAPI]
public sealed record ChangesBody
{
    [JsonPropertyName("from")]
    public string From { get; init; } = null!;
}
