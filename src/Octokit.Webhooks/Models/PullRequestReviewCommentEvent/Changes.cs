namespace Octokit.Webhooks.Models.PullRequestReviewCommentEvent;

[PublicAPI]
public sealed record Changes
{
    [JsonPropertyName("body")]
    public ChangesBody? Body { get; init; }
}
