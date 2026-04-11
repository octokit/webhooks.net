namespace Octokit.Webhooks.Events.SecretScanningAlert;

[PublicAPI]
[WebhookActionType(SecretScanningAlertActionValue.Unassigned)]
public sealed record SecretScanningAlertUnassignedEvent : SecretScanningAlertEvent
{
    [JsonPropertyName("action")]
    public override string Action => SecretScanningAlertAction.Unassigned;
}
