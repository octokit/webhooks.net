namespace Octokit.Webhooks.Events.SecretScanningAlert;

[PublicAPI]
[WebhookActionType(SecretScanningAlertActionValue.Assigned)]
public sealed record SecretScanningAlertAssignedEvent : SecretScanningAlertEvent
{
    [JsonPropertyName("action")]
    public override string Action => SecretScanningAlertAction.Assigned;
}
