namespace Octokit.Webhooks.Events.IssueComment;

[PublicAPI]
public sealed record IssueCommentAction : WebhookEventAction
{
    public static readonly IssueCommentAction Created = new(IssueCommentActionValue.Created);

    public static readonly IssueCommentAction Deleted = new(IssueCommentActionValue.Deleted);

    public static readonly IssueCommentAction Edited = new(IssueCommentActionValue.Edited);

    private IssueCommentAction(string value)
        : base(value)
    {
    }
}
