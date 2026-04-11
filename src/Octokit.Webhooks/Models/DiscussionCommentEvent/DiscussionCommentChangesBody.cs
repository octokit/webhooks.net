namespace Octokit.Webhooks.Models.DiscussionCommentEvent;

[PublicAPI]
public sealed record DiscussionCommentChangesBody
{
    [JsonPropertyName("from")]
    public required string From { get; init; }
}
