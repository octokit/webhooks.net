namespace Octokit.Webhooks.Events.SubIssues;

[PublicAPI]
[WebhookActionType(SubIssuesActionValue.SubIssueRemoved)]
public sealed record SubIssuesSubIssueRemovedEvent : SubIssuesEvent
{
    [JsonPropertyName("action")]
    public override string Action => SubIssuesAction.SubIssueRemoved;
}
