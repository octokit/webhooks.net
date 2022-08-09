namespace Octokit.Webhooks.Events.CodeScanningAlert;

[PublicAPI]
[WebhookActionType(CodeScanningAlertActionValue.ReopenedByUser)]
public sealed record CodeScanningAlertReopenedByUserEvent : CodeScanningAlertEvent
{
    [JsonPropertyName("action")]
    public override string Action => CodeScanningAlertAction.ReopenedByUser;
}
