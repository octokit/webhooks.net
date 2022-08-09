namespace Octokit.Webhooks.Events.CodeScanningAlert;

[PublicAPI]
[WebhookActionType(CodeScanningAlertActionValue.ClosedByUser)]
public sealed record CodeScanningAlertClosedByUserEvent : CodeScanningAlertEvent
{
    [JsonPropertyName("action")]
    public override string Action => CodeScanningAlertAction.ClosedByUser;
}
