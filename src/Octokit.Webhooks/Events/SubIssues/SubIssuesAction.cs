namespace Octokit.Webhooks.Events.SubIssues;

[PublicAPI]
public sealed record SubIssuesAction : WebhookEventAction
{
    public static readonly SubIssuesAction ParentIssueAdded = new(SubIssuesActionValue.ParentIssueAdded);

    public static readonly SubIssuesAction ParentIssueRemoved = new(SubIssuesActionValue.ParentIssueRemoved);

    public static readonly SubIssuesAction SubIssueAdded = new(SubIssuesActionValue.SubIssueAdded);

    public static readonly SubIssuesAction SubIssueRemoved = new(SubIssuesActionValue.SubIssueRemoved);

    private SubIssuesAction(string value)
        : base(value)
    {
    }
}
