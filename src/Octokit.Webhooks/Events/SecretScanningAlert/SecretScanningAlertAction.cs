namespace Octokit.Webhooks.Events.SecretScanningAlert;

[PublicAPI]
public sealed record SecretScanningAlertAction : WebhookEventAction
{
    public static readonly SecretScanningAlertAction Created = new(SecretScanningAlertActionValue.Created);

    public static readonly SecretScanningAlertAction Reopened = new(SecretScanningAlertActionValue.Reopened);

    public static readonly SecretScanningAlertAction Resolved = new(SecretScanningAlertActionValue.Resolved);

    public static readonly SecretScanningAlertAction Revoked = new(SecretScanningAlertActionValue.Revoked);

    private SecretScanningAlertAction(string value)
        : base(value)
    {
    }
}
