namespace JamieMagee.Octokit.Webhooks.Events.PullRequestReview
{
    public sealed class PullRequestReviewAction : WebhookEventAction
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
