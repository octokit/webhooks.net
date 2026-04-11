namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.IssueComment)]
[JsonConverter(typeof(WebhookConverter<IssueCommentEvent>))]
public abstract record IssueCommentEvent : WebhookEvent
{
    [JsonPropertyName("issue")]
    public required Issue Issue { get; init; }

    [JsonPropertyName("comment")]
    public required Models.IssueComment Comment { get; init; }
}
