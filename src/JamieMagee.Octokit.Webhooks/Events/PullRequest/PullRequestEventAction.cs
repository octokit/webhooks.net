namespace JamieMagee.Octokit.Webhooks.Events.PullRequest
{
    public sealed class PullRequestEventAction : WebhookEventAction
    {
        public static readonly PullRequestEventAction Assigned = new(PullRequestEventActionValue.Assigned);

        public static readonly PullRequestEventAction AutoMergeDisabled = new(PullRequestEventActionValue.AutoMergeDisabled);

        public static readonly PullRequestEventAction AutoMergeEnabled = new(PullRequestEventActionValue.AutoMergeEnabled);

        public static readonly PullRequestEventAction Closed = new(PullRequestEventActionValue.Closed);

        public static readonly PullRequestEventAction ConvertedToDraft = new(PullRequestEventActionValue.ConvertedToDraft);

        public static readonly PullRequestEventAction Edited = new(PullRequestEventActionValue.Edited);

        public static readonly PullRequestEventAction Labeled = new(PullRequestEventActionValue.Labeled);

        public static readonly PullRequestEventAction Locked = new(PullRequestEventActionValue.Locked);

        public static readonly PullRequestEventAction Opened = new(PullRequestEventActionValue.Opened);

        public static readonly PullRequestEventAction ReadyForReview = new(PullRequestEventActionValue.ReadyForReview);

        public static readonly PullRequestEventAction Reopened = new(PullRequestEventActionValue.Reopened);

        public static readonly PullRequestEventAction ReviewRequested = new(PullRequestEventActionValue.ReviewRequested);

        public static readonly PullRequestEventAction ReviewRequestedRemoved = new(PullRequestEventActionValue.ReviewRequestedRemoved);

        public static readonly PullRequestEventAction Synchronize = new(PullRequestEventActionValue.Synchronize);

        public static readonly PullRequestEventAction Unassigned = new(PullRequestEventActionValue.Unassigned);

        public static readonly PullRequestEventAction Unlabeled = new(PullRequestEventActionValue.Unlabeled);

        public static readonly PullRequestEventAction Unlocked = new(PullRequestEventActionValue.Unlocked);

        private PullRequestEventAction(string value)
            : base(value)
        {
        }
    }
}
