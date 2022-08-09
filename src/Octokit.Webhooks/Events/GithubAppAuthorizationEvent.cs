namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.GithubAppAuthorization)]
[JsonConverter(typeof(WebhookConverter<GithubAppAuthorizationEvent>))]
public abstract record GithubAppAuthorizationEvent : WebhookEvent;
