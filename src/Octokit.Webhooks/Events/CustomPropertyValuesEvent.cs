namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.CustomPropertyValues)]
[JsonConverter(typeof(WebhookConverter<CustomPropertyValuesEvent>))]
public abstract record CustomPropertyValuesEvent : WebhookEvent;
