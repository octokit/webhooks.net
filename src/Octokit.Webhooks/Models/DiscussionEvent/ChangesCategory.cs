namespace Octokit.Webhooks.Models.DiscussionEvent;

[PublicAPI]
public sealed record ChangesCategory
{
    [JsonPropertyName("from")]
    public DiscussionCategory From { get; init; } = null!;
}
