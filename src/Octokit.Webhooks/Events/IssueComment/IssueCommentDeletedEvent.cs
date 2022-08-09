namespace Octokit.Webhooks.Events.IssueComment;

[PublicAPI]
[WebhookActionType(IssueCommentActionValue.Deleted)]
public sealed record IssueCommentDeletedEvent : IssueCommentEvent
{
    [JsonPropertyName("action")]
    public override string Action => IssueCommentAction.Deleted;
}
