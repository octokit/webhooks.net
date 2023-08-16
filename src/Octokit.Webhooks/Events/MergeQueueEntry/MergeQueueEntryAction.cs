namespace Octokit.Webhooks.Events.MergeQueueEntry;

[PublicAPI]
public sealed record MergeQueueEntryAction : WebhookEventAction
{
    public static readonly MergeQueueEntryAction Created = new(MergeQueueEntryActionValue.Created);

    public static readonly MergeQueueEntryAction Deleted = new(MergeQueueEntryActionValue.Deleted);

    private MergeQueueEntryAction(string value)
        : base(value)
    {
    }
}
