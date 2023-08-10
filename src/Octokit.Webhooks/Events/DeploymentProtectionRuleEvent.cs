namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.DeploymentProtectionRule)]
[JsonConverter(typeof(WebhookConverter<DeploymentProtectionRuleEvent>))]
public abstract record DeploymentProtectionRuleEvent : WebhookEvent;
