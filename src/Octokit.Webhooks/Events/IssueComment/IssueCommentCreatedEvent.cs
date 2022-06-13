namespace Octokit.Webhooks.Events.IssueComment;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(IssueCommentActionValue.Created)]
public sealed record IssueCommentCreatedEvent : IssueCommentEvent
{
    [JsonPropertyName("action")]
    public override string Action => IssueCommentAction.Created;
}