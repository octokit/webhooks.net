namespace Octokit.Webhooks.Events.Issues;

[PublicAPI]
public sealed record IssuesAction : WebhookEventAction
{
    public static readonly IssuesAction Assigned = new(IssuesActionValue.Assigned);

    public static readonly IssuesAction Closed = new(IssuesActionValue.Closed);

    public static readonly IssuesAction Deleted = new(IssuesActionValue.Deleted);

    public static readonly IssuesAction Demilestoned = new(IssuesActionValue.Demilestoned);

    public static readonly IssuesAction Edited = new(IssuesActionValue.Edited);

    public static readonly IssuesAction Labeled = new(IssuesActionValue.Labeled);

    public static readonly IssuesAction Locked = new(IssuesActionValue.Locked);

    public static readonly IssuesAction Milestoned = new(IssuesActionValue.Milestoned);

    public static readonly IssuesAction Opened = new(IssuesActionValue.Opened);

    public static readonly IssuesAction Pinned = new(IssuesActionValue.Pinned);

    public static readonly IssuesAction Reopened = new(IssuesActionValue.Reopened);

    public static readonly IssuesAction Transferred = new(IssuesActionValue.Transferred);

    public static readonly IssuesAction Typed = new(IssuesActionValue.Typed);

    public static readonly IssuesAction Unassigned = new(IssuesActionValue.Unassigned);

    public static readonly IssuesAction Unlabeled = new(IssuesActionValue.Unlabeled);

    public static readonly IssuesAction Unlocked = new(IssuesActionValue.Unlocked);

    public static readonly IssuesAction Unpinned = new(IssuesActionValue.Unpinned);

    public static readonly IssuesAction Untyped = new(IssuesActionValue.Untyped);

    private IssuesAction(string value)
        : base(value)
    {
    }
}
