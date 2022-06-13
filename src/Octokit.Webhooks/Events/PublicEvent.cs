namespace Octokit.Webhooks.Events;

using JetBrains.Annotations;

[PublicAPI]
[WebhookEventType(WebhookEventType.Public)]
public sealed record PublicEvent : WebhookEvent;