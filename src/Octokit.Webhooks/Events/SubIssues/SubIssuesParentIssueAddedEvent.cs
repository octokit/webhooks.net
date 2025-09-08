namespace Octokit.Webhooks.Events.SubIssues;

[PublicAPI]
[WebhookActionType(SubIssuesActionValue.ParentIssueAdded)]
public sealed record SubIssuesParentIssueAddedEvent : SubIssuesEvent
{
    [JsonPropertyName("action")]
    public override string Action => SubIssuesAction.ParentIssueAdded;
}
