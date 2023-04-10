namespace Octokit.Webhooks.Events.PullRequest;

[PublicAPI]
public sealed record PullRequestAction : WebhookEventAction
{
    public static readonly PullRequestAction Assigned = new(PullRequestActionValue.Assigned);

    public static readonly PullRequestAction AutoMergeDisabled = new(PullRequestActionValue.AutoMergeDisabled);

    public static readonly PullRequestAction AutoMergeEnabled = new(PullRequestActionValue.AutoMergeEnabled);

    public static readonly PullRequestAction Closed = new(PullRequestActionValue.Closed);

    public static readonly PullRequestAction ConvertedToDraft = new(PullRequestActionValue.ConvertedToDraft);

    public static readonly PullRequestAction Dequeued = new(PullRequestActionValue.Dequeued);

    public static readonly PullRequestAction Demilestoned = new(PullRequestActionValue.Demilestoned);

    public static readonly PullRequestAction Edited = new(PullRequestActionValue.Edited);

    public static readonly PullRequestAction Labeled = new(PullRequestActionValue.Labeled);

    public static readonly PullRequestAction Locked = new(PullRequestActionValue.Locked);

    public static readonly PullRequestAction Milestoned = new(PullRequestActionValue.Milestoned);

    public static readonly PullRequestAction Opened = new(PullRequestActionValue.Opened);

    public static readonly PullRequestAction Queued = new(PullRequestActionValue.Queued);

    public static readonly PullRequestAction ReadyForReview = new(PullRequestActionValue.ReadyForReview);

    public static readonly PullRequestAction Reopened = new(PullRequestActionValue.Reopened);

    public static readonly PullRequestAction ReviewRequestRemoved = new(PullRequestActionValue.ReviewRequestRemoved);

    public static readonly PullRequestAction ReviewRequested = new(PullRequestActionValue.ReviewRequested);

    public static readonly PullRequestAction Synchronize = new(PullRequestActionValue.Synchronize);

    public static readonly PullRequestAction Unassigned = new(PullRequestActionValue.Unassigned);

    public static readonly PullRequestAction Unlabeled = new(PullRequestActionValue.Unlabeled);

    public static readonly PullRequestAction Unlocked = new(PullRequestActionValue.Unlocked);

    private PullRequestAction(string value)
        : base(value)
    {
    }
}
