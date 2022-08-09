namespace Octokit.Webhooks.Models.PullRequestReviewEvent;

[PublicAPI]
public sealed record Changes
{
    [JsonPropertyName("body")]
    public ChangesBody? Body { get; init; }
}
