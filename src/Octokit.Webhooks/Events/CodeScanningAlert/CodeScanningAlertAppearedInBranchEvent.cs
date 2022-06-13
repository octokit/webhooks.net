namespace Octokit.Webhooks.Events.CodeScanningAlert;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(CodeScanningAlertActionValue.AppearedInBranch)]
public sealed record CodeScanningAlertAppearedInBranchEvent : CodeScanningAlertEvent
{
    [JsonPropertyName("action")]
    public override string Action => CodeScanningAlertAction.AppearedInBranch;
}