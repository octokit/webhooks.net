namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.IssueDependencies)]
[JsonConverter(typeof(WebhookConverter<IssueDependenciesEvent>))]
public abstract record IssueDependenciesEvent : WebhookEvent
{
    [JsonPropertyName("blocked_issue")]
    public Issue? BlockedIssue { get; init; }

    [JsonPropertyName("blocking_issue")]
    public Issue? BlockingIssue { get; init; }

    [JsonPropertyName("blocked_issue_id")]
    public long? BlockedIssueId { get; init; }

    [JsonPropertyName("blocking_issue_id")]
    public long? BlockingIssueId { get; init; }
}
