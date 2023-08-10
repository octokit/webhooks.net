namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.RepositoryRuleset)]
public abstract record RepositoryRulesetEvent : WebhookEvent;
