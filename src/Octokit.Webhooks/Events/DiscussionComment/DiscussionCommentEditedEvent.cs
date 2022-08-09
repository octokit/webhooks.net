namespace Octokit.Webhooks.Events.DiscussionComment;

using Octokit.Webhooks.Models.DiscussionCommentEvent;

[PublicAPI]
[WebhookActionType(DiscussionCommentActionValue.Edited)]
public sealed record DiscussionCommentEditedEvent : DiscussionCommentEvent
{
    [JsonPropertyName("action")]
    public override string Action => DiscussionCommentAction.Edited;

    [JsonPropertyName("changes")]
    public Changes Changes { get; init; } = null!;
}
