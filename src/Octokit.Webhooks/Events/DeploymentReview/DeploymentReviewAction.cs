namespace Octokit.Webhooks.Events.DeploymentReview;

[PublicAPI]
public sealed record DeploymentReviewAction : WebhookEventAction
{
    public static readonly DeploymentReviewAction Approved = new(DeploymentReviewActionValue.Approved);

    public static readonly DeploymentReviewAction Rejected = new(DeploymentReviewActionValue.Rejected);

    public static readonly DeploymentReviewAction Requested = new(DeploymentReviewActionValue.Requested);

    private DeploymentReviewAction(string value)
        : base(value)
    {
    }
}
