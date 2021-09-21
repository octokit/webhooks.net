namespace Octokit.Webhooks.Events.PullRequestReview
{
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record PullRequestReviewAction : WebhookEventAction
    {
        public static readonly PullRequestReviewAction Dismissed = new(PullRequestReviewActionValue.Dismissed);

        public static readonly PullRequestReviewAction Edited = new(PullRequestReviewActionValue.Edited);

        public static readonly PullRequestReviewAction Submitted = new(PullRequestReviewActionValue.Submitted);

        private PullRequestReviewAction(string value)
            : base(value)
        {
        }
    }
}
