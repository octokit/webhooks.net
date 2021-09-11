namespace JamieMagee.Octokit.Webhooks.Events.CodeScanningAlert
{
    public sealed class CodeScanningAlertAction : WebhookEventAction
    {
        public static readonly CodeScanningAlertAction AppearedInBranch = new(CodeScanningAlertActionValue.AppearedInBranch);

        public static readonly CodeScanningAlertAction ClosedByUser = new(CodeScanningAlertActionValue.ClosedByUser);

        public static readonly CodeScanningAlertAction Created = new(CodeScanningAlertActionValue.Created);

        public static readonly CodeScanningAlertAction Fixed = new(CodeScanningAlertActionValue.Fixed);

        public static readonly CodeScanningAlertAction Reopened = new(CodeScanningAlertActionValue.Reopened);

        public static readonly CodeScanningAlertAction ReopenedByUser = new(CodeScanningAlertActionValue.ReopenedByUser);

        private CodeScanningAlertAction(string value)
            : base(value)
        {
        }
    }
}
