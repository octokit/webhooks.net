namespace Octokit.Webhooks.Models.DiscussionEvent;

[PublicAPI]
public sealed record ChangesCategory
{
    [JsonPropertyName("from")]
    public required DiscussionCategory From { get; init; }
}
