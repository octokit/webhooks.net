namespace Octokit.Webhooks.Events.Discussion;

[PublicAPI]
public sealed record DiscussionAction : WebhookEventAction
{
    public static readonly DiscussionAction Answered = new(DiscussionActionValue.Answered);

    public static readonly DiscussionAction CategoryChanged = new(DiscussionActionValue.CategoryChanged);

    public static readonly DiscussionAction Created = new(DiscussionActionValue.Created);

    public static readonly DiscussionAction Deleted = new(DiscussionActionValue.Deleted);

    public static readonly DiscussionAction Edited = new(DiscussionActionValue.Edited);

    public static readonly DiscussionAction Labeled = new(DiscussionActionValue.Labeled);

    public static readonly DiscussionAction Locked = new(DiscussionActionValue.Locked);

    public static readonly DiscussionAction Pinned = new(DiscussionActionValue.Pinned);

    public static readonly DiscussionAction Transferred = new(DiscussionActionValue.Transferred);

    public static readonly DiscussionAction Unanswered = new(DiscussionActionValue.Unanswered);

    public static readonly DiscussionAction Unlabeled = new(DiscussionActionValue.Unlabeled);

    public static readonly DiscussionAction Unlocked = new(DiscussionActionValue.Unlocked);

    public static readonly DiscussionAction Unpinned = new(DiscussionActionValue.Unpinned);

    private DiscussionAction(string value)
        : base(value)
    {
    }
}
