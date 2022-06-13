namespace Octokit.Webhooks.Events.DiscussionComment;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(DiscussionCommentActionValue.Deleted)]
public sealed record DiscussionCommentDeletedEvent : DiscussionCommentEvent
{
    [JsonPropertyName("action")]
    public override string Action => DiscussionCommentAction.Deleted;
}