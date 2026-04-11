namespace Octokit.Webhooks.Events.IssueComment;

[PublicAPI]
[WebhookActionType(IssueCommentActionValue.Pinned)]
public sealed record IssueCommentPinnedEvent : IssueCommentEvent
{
    [JsonPropertyName("action")]
    public override string Action => IssueCommentAction.Pinned;
}
