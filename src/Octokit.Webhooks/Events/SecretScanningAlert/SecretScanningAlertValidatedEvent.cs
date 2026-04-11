namespace Octokit.Webhooks.Events.SecretScanningAlert;

[PublicAPI]
[WebhookActionType(SecretScanningAlertActionValue.Validated)]
public sealed record SecretScanningAlertValidatedEvent : SecretScanningAlertEvent
{
    [JsonPropertyName("action")]
    public override string Action => SecretScanningAlertAction.Validated;
}
