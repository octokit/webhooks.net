namespace Octokit.Webhooks.Events.CodeScanningAlert;

[PublicAPI]
[WebhookActionType(CodeScanningAlertActionValue.UpdatedAssignment)]
public sealed record CodeScanningAlertUpdatedAssignmentEvent : CodeScanningAlertEvent
{
    [JsonPropertyName("action")]
    public override string Action => CodeScanningAlertAction.UpdatedAssignment;
}
