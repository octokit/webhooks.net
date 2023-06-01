namespace Octokit.Webhooks.Events.SecretScanningAlertLocation;

public sealed record SecretScanningAlertLocationAction : WebhookEventAction
{
    public static readonly SecretScanningAlertLocationAction Created = new(SecretScanningAlertLocationActionValue.Created);

    private SecretScanningAlertLocationAction(string value)
        : base(value)
    {
    }
}
