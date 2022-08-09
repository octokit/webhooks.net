namespace Octokit.Webhooks.Events.CommitComment;

[PublicAPI]
public sealed record CommitCommentAction : WebhookEventAction
{
    public static readonly CommitCommentAction Created = new(CommitCommentActionValue.Created);

    private CommitCommentAction(string value)
        : base(value)
    {
    }
}
