namespace Octokit.Webhooks.Events.SecretScanningAlert;

using JetBrains.Annotations;

[PublicAPI]
public sealed record SecretScanningAlertAction : WebhookEventAction
{
    public static readonly SecretScanningAlertAction Created = new(SecretScanningAlertActionValue.Created);

    public static readonly SecretScanningAlertAction Reopened = new(SecretScanningAlertActionValue.Reopened);

    public static readonly SecretScanningAlertAction Resolved = new(SecretScanningAlertActionValue.Resolved);

    private SecretScanningAlertAction(string value)
        : base(value)
    {
    }
}