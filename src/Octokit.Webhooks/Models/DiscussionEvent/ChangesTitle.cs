namespace Octokit.Webhooks.Models.DiscussionEvent;

[PublicAPI]
public sealed record ChangesTitle
{
    [JsonPropertyName("from")]
    public string From { get; init; } = null!;
}
