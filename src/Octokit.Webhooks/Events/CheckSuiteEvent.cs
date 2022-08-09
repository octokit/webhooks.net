namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.CheckSuite)]
[JsonConverter(typeof(WebhookConverter<CheckSuiteEvent>))]
public abstract record CheckSuiteEvent : WebhookEvent
{
    [JsonPropertyName("check_suite")]
    public Models.CheckSuiteEvent.CheckSuite CheckSuite { get; init; } = null!;
}
