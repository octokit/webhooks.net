namespace Octokit.Webhooks.Models.PullRequestReviewThreadEvent;

[PublicAPI]
public sealed record Thread
{
    [JsonPropertyName("node_id")]
    public required string NodeId { get; init; }

    [JsonPropertyName("comments")]
    public required IReadOnlyList<PullRequestReviewComment> Comments { get; init; }
}
