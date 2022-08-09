namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.Organization)]
[JsonConverter(typeof(WebhookConverter<OrganizationEvent>))]
public abstract record OrganizationEvent : WebhookEvent;
