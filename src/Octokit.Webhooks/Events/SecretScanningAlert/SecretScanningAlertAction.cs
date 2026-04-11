namespace Octokit.Webhooks.Events.SecretScanningAlert;

[PublicAPI]
public sealed record SecretScanningAlertAction : WebhookEventAction
{
    public static readonly SecretScanningAlertAction Created = new(SecretScanningAlertActionValue.Created);

    public static readonly SecretScanningAlertAction Reopened = new(SecretScanningAlertActionValue.Reopened);

    public static readonly SecretScanningAlertAction Resolved = new(SecretScanningAlertActionValue.Resolved);

    public static readonly SecretScanningAlertAction Revoked = new(SecretScanningAlertActionValue.Revoked);

    public static readonly SecretScanningAlertAction Assigned = new(SecretScanningAlertActionValue.Assigned);
    public static readonly SecretScanningAlertAction PubliclyLeaked = new(SecretScanningAlertActionValue.PubliclyLeaked);
    public static readonly SecretScanningAlertAction Unassigned = new(SecretScanningAlertActionValue.Unassigned);
    public static readonly SecretScanningAlertAction Validated = new(SecretScanningAlertActionValue.Validated);

    private SecretScanningAlertAction(string value)
        : base(value)
    {
    }
}
