namespace Octokit.Webhooks.Events.SecretScanningAlert;

[PublicAPI]
[WebhookActionType(SecretScanningAlertActionValue.PubliclyLeaked)]
public sealed record SecretScanningAlertPubliclyLeakedEvent : SecretScanningAlertEvent
{
    [JsonPropertyName("action")]
    public override string Action => SecretScanningAlertAction.PubliclyLeaked;
}
