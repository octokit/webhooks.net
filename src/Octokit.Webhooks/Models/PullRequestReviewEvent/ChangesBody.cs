namespace Octokit.Webhooks.Models.PullRequestReviewEvent;

[PublicAPI]
public sealed record ChangesBody
{
    [JsonPropertyName("from")]
    public string From { get; init; } = null!;
}
