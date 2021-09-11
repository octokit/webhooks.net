namespace JamieMagee.Octokit.Webhooks.Events.SecretScanningAlert
{
    public sealed class SecretScanningAlertAction : WebhookEventAction
    {
        public static readonly SecretScanningAlertAction Created = new(SecretScanningAlertActionValue.Created);

        public static readonly SecretScanningAlertAction Reopened = new(SecretScanningAlertActionValue.Reopened);

        public static readonly SecretScanningAlertAction Resolved = new(SecretScanningAlertActionValue.Resolved);

        private SecretScanningAlertAction(string value)
            : base(value)
        {
        }
    }
}
