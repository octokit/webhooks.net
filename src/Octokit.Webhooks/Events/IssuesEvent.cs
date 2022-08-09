namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.Issues)]
[JsonConverter(typeof(WebhookConverter<IssuesEvent>))]
public abstract record IssuesEvent : WebhookEvent
{
    [JsonPropertyName("issue")]
    public Issue Issue { get; init; } = null!;
}
