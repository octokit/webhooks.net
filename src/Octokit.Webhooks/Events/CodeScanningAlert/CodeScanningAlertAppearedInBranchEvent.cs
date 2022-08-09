namespace Octokit.Webhooks.Events.CodeScanningAlert;

[PublicAPI]
[WebhookActionType(CodeScanningAlertActionValue.AppearedInBranch)]
public sealed record CodeScanningAlertAppearedInBranchEvent : CodeScanningAlertEvent
{
    [JsonPropertyName("action")]
    public override string Action => CodeScanningAlertAction.AppearedInBranch;
}
