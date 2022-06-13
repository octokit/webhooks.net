namespace Octokit.Webhooks.Events.DiscussionComment;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(DiscussionCommentActionValue.Created)]
public sealed record DiscussionCommentCreatedEvent : DiscussionCommentEvent
{
    [JsonPropertyName("action")]
    public override string Action => DiscussionCommentAction.Created;
}