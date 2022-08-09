namespace Octokit.Webhooks.Events;

// TODO: Undocumented event
[PublicAPI]
[WebhookEventType(WebhookEventType.DeploymentReview)]
[JsonConverter(typeof(WebhookConverter<DeploymentReviewEvent>))]
public abstract record DeploymentReviewEvent : WebhookEvent;
