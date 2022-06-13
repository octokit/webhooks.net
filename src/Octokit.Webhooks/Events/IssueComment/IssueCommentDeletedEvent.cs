namespace Octokit.Webhooks.Events.IssueComment;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(IssueCommentActionValue.Deleted)]
public sealed record IssueCommentDeletedEvent : IssueCommentEvent
{
    [JsonPropertyName("action")]
    public override string Action => IssueCommentAction.Deleted;
}
