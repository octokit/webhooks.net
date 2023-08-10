namespace Octokit.Webhooks.Events.DeploymentReview;

[PublicAPI]
[WebhookActionType(DeploymentReviewActionValue.Requested)]
public sealed record DeploymentReviewRequestedEvent : DeploymentReviewEvent
{
    [JsonPropertyName("action")]
    public override string Action => DeploymentReviewAction.Requested;
}
