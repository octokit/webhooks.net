namespace Octokit.Webhooks.Events.DeploymentReview;

[PublicAPI]
public static class DeploymentReviewActionValue
{
    public const string Approved = "approved";

    public const string Rejected = "rejected";

    public const string Requested = "requested";
}
