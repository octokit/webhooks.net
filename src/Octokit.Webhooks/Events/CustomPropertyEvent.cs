namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.CustomProperty)]
[JsonConverter(typeof(WebhookConverter<CustomPropertyEvent>))]
public abstract record CustomPropertyEvent : WebhookEvent;
