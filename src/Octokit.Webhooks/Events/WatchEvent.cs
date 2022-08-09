namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.Watch)]
[JsonConverter(typeof(WebhookConverter<WatchEvent>))]
public abstract record WatchEvent : WebhookEvent;
