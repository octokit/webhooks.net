namespace Octokit.Webhooks.Events.PullRequestReviewThread;

using JetBrains.Annotations;

[PublicAPI]
public sealed record PullRequestReviewThreadAction : WebhookEventAction
{
    public static readonly PullRequestReviewThreadAction Resolved = new(PullRequestReviewThreadActionValue.Resolved);

    public static readonly PullRequestReviewThreadAction Unresolved = new(PullRequestReviewThreadActionValue.Unresolved);

    private PullRequestReviewThreadAction(string value)
        : base(value)
    {
    }
}