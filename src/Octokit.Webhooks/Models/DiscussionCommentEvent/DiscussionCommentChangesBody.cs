namespace Octokit.Webhooks.Models.DiscussionCommentEvent;

[PublicAPI]
public sealed record DiscussionCommentChangesBody
{
    [JsonPropertyName("from")]
    public string From { get; init; } = null!;
}
