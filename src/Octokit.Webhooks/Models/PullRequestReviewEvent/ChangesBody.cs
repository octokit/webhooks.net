namespace Octokit.Webhooks.Models.PullRequestReviewEvent;

[PublicAPI]
public sealed record ChangesBody
{
    [JsonPropertyName("from")]
    public required string From { get; init; }
}
