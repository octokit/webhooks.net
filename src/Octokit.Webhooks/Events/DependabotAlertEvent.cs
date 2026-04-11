namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.DependabotAlert)]
[JsonConverter(typeof(WebhookConverter<DependabotAlertEvent>))]
public abstract record DependabotAlertEvent : WebhookEvent
{
    [JsonPropertyName("alert")]
    public required Models.DependabotEvent.DependabotAlert Alert { get; init; }
}
