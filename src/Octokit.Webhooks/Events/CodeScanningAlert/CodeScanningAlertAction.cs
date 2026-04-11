namespace Octokit.Webhooks.Events.CodeScanningAlert;

[PublicAPI]
public sealed record CodeScanningAlertAction : WebhookEventAction
{
    public static readonly CodeScanningAlertAction AppearedInBranch = new(CodeScanningAlertActionValue.AppearedInBranch);

    public static readonly CodeScanningAlertAction ClosedByUser = new(CodeScanningAlertActionValue.ClosedByUser);

    public static readonly CodeScanningAlertAction Created = new(CodeScanningAlertActionValue.Created);

    public static readonly CodeScanningAlertAction Fixed = new(CodeScanningAlertActionValue.Fixed);

    public static readonly CodeScanningAlertAction Reopened = new(CodeScanningAlertActionValue.Reopened);

    public static readonly CodeScanningAlertAction ReopenedByUser = new(CodeScanningAlertActionValue.ReopenedByUser);

    public static readonly CodeScanningAlertAction UpdatedAssignment = new(CodeScanningAlertActionValue.UpdatedAssignment);

    private CodeScanningAlertAction(string value)
        : base(value)
    {
    }
}
