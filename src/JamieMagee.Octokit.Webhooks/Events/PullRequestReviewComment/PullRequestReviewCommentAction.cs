namespace JamieMagee.Octokit.Webhooks.Events.PullRequestReviewComment
{
    public sealed class PullRequestReviewCommentAction : WebhookEventAction
    {
        public static readonly PullRequestReviewCommentAction Created = new(PullRequestReviewCommentActionValue.Created);

        public static readonly PullRequestReviewCommentAction Deleted = new(PullRequestReviewCommentActionValue.Deleted);

        public static readonly PullRequestReviewCommentAction Edited = new(PullRequestReviewCommentActionValue.Edited);

        private PullRequestReviewCommentAction(string value)
            : base(value)
        {
        }
    }
}
