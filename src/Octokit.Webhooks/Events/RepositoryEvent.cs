namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.Repository)]
[JsonConverter(typeof(WebhookConverter<RepositoryEvent>))]
public abstract record RepositoryEvent : WebhookEvent;
