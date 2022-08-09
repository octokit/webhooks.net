namespace Octokit.Webhooks.Models.DiscussionCommentEvent;

[PublicAPI]
public sealed record Changes
{
    [JsonPropertyName("body")]
    public Changes? Body { get; init; }
}
