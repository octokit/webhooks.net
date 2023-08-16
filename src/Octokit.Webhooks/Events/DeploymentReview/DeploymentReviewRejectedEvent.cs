namespace Octokit.Webhooks.Events.DeploymentReview;

[PublicAPI]
[WebhookActionType(DeploymentReviewActionValue.Rejected)]
public sealed record DeploymentReviewRejectedEvent : DeploymentReviewEvent
{
    [JsonPropertyName("action")]
    public override string Action => DeploymentReviewAction.Rejected;
}
