namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.RegistryPackage)]
[JsonConverter(typeof(WebhookConverter<RegistryPackageEvent>))]
public abstract record RegistryPackageEvent : WebhookEvent;
