namespace Octokit.Webhooks.Events.DeploymentReview;

[PublicAPI]
[WebhookActionType(DeploymentReviewActionValue.Approved)]
public sealed record DeploymentReviewApprovedEvent : DeploymentReviewEvent
{
    [JsonPropertyName("action")]
    public override string Action => DeploymentReviewAction.Approved;
}
