namespace Octokit.Webhooks.Events.SecretScanningScan;

[PublicAPI]
public sealed record SecretScanningScanAction : WebhookEventAction
{
    public static readonly SecretScanningScanAction Completed = new(SecretScanningScanActionValue.Completed);

    private SecretScanningScanAction(string value)
        : base(value)
    {
    }
}
