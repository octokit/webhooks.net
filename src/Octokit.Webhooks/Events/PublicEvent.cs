namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.Public)]
public sealed record PublicEvent : WebhookEvent;
