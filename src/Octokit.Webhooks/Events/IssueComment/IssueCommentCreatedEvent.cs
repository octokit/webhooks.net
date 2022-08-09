namespace Octokit.Webhooks.Events.IssueComment;

[PublicAPI]
[WebhookActionType(IssueCommentActionValue.Created)]
public sealed record IssueCommentCreatedEvent : IssueCommentEvent
{
    [JsonPropertyName("action")]
    public override string Action => IssueCommentAction.Created;
}
