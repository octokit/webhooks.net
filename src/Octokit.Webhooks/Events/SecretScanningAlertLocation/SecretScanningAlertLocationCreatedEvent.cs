namespace Octokit.Webhooks.Events.SecretScanningAlertLocation;

[PublicAPI]
[WebhookActionType(SecretScanningAlertLocationActionValue.Created)]
public sealed record SecretScanningAlertLocationCreatedEvent : SecretScanningAlertEvent
{
    [JsonPropertyName("action")]
    public override string Action => SecretScanningAlertLocationAction.Created;
}
