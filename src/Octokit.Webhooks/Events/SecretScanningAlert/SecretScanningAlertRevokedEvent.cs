namespace Octokit.Webhooks.Events.SecretScanningAlert;

[PublicAPI]
[WebhookActionType(SecretScanningAlertActionValue.Revoked)]
public sealed record SecretScanningAlertRevokedEvent : SecretScanningAlertEvent
{
    [JsonPropertyName("action")]
    public override string Action => SecretScanningAlertAction.Revoked;
}
