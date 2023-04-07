namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.InstallationTarget)]
[JsonConverter(typeof(WebhookConverter<InstallationTargetEvent>))]
public abstract record InstallationTargetEvent : WebhookEvent;
