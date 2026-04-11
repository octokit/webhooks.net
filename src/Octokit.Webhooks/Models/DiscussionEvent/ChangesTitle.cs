namespace Octokit.Webhooks.Models.DiscussionEvent;

[PublicAPI]
public sealed record ChangesTitle
{
    [JsonPropertyName("from")]
    public required string From { get; init; }
}
