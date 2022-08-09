namespace Octokit.Webhooks.Models.PullRequestReviewThreadEvent;

[PublicAPI]
public sealed record Thread
{
    [JsonPropertyName("node_id")]
    public string NodeId { get; init; } = null!;

    [JsonPropertyName("comments")]
    public IEnumerable<PullRequestReviewComment> Comments { get; init; } = null!;
}
