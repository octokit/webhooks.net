namespace Octokit.Webhooks.Events.SubIssues;

[PublicAPI]
[WebhookActionType(SubIssuesActionValue.SubIssueAdded)]
public sealed record SubIssuesSubIssueAddedEvent : SubIssuesEvent
{
    [JsonPropertyName("action")]
    public override string Action => SubIssuesAction.SubIssueAdded;
}
