namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.DeploymentReview)]
[JsonConverter(typeof(WebhookConverter<DeploymentReviewEvent>))]
public abstract record DeploymentReviewEvent : WebhookEvent;
