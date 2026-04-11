namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.DeployKey)]
[JsonConverter(typeof(WebhookConverter<DeployKeyEvent>))]
public abstract record DeployKeyEvent : WebhookEvent
{
    [JsonPropertyName("key")]
    public required Models.DeployKeyEvent.DeployKey Key { get; init; }
}
