namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.SubIssues)]
[JsonConverter(typeof(WebhookConverter<SubIssuesEvent>))]
public abstract record SubIssuesEvent : WebhookEvent
{
    [JsonPropertyName("parent_issue_id")]
    public long ParentIssueId { get; init; }

    [JsonPropertyName("parent_issue")]
    public required Issue ParentIssue { get; init; }

    [JsonPropertyName("parent_issue_repo")]
    public Models.Repository? ParentIssueRepo { get; init; }

    [JsonPropertyName("sub_issue_id")]
    public long SubIssueId { get; init; }

    [JsonPropertyName("sub_issue")]
    public required Issue SubIssue { get; init; }

    [JsonPropertyName("sub_issue_repo")]
    public Models.Repository? SubIssueRepo { get; init; }
}
