namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.BranchProtectionConfiguration)]
[JsonConverter(typeof(WebhookConverter<BranchProtectionConfigurationEvent>))]
public abstract record BranchProtectionConfigurationEvent : WebhookEvent;
