namespace Octokit.Webhooks.Events.IssueComment;

[PublicAPI]
[WebhookActionType(IssueCommentActionValue.Unpinned)]
public sealed record IssueCommentUnpinnedEvent : IssueCommentEvent
{
    [JsonPropertyName("action")]
    public override string Action => IssueCommentAction.Unpinned;
}
