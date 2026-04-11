namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.Issues)]
[JsonConverter(typeof(WebhookConverter<IssuesEvent>))]
public abstract record IssuesEvent : WebhookEvent
{
    [JsonPropertyName("issue")]
    public required Issue Issue { get; init; }
}
