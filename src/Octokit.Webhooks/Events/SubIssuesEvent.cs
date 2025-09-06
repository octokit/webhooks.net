namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.SubIssues)]
[JsonConverter(typeof(WebhookConverter<SubIssuesEvent>))]
public abstract record SubIssuesEvent : WebhookEvent
{
    [JsonPropertyName("parent_issue_id")]
    public long ParentIssueId { get; init; }

    [JsonPropertyName("parent_issue")]
    public Issue ParentIssue { get; init; } = null!;

    [JsonPropertyName("parent_issue_repo")]
    public Models.Repository? ParentIssueRepo { get; init; } = null!;

    [JsonPropertyName("sub_issue_id")]
    public long SubIssueId { get; init; }

    [JsonPropertyName("sub_issue")]
    public Issue SubIssue { get; init; } = null!;

    [JsonPropertyName("sub_issue_repo")]
    public Models.Repository? SubIssueRepo { get; init; }
}
