namespace Octokit.Webhooks.Events.SubIssues;

[PublicAPI]
[WebhookActionType(SubIssuesActionValue.ParentIssueRemoved)]
public sealed record SubIssuesParentIssueRemovedEvent : SubIssuesEvent
{
    [JsonPropertyName("action")]
    public override string Action => SubIssuesAction.ParentIssueRemoved;
}
