namespace Octokit.Webhooks.Events.CodeScanningAlert;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(CodeScanningAlertActionValue.Reopened)]
public sealed record CodeScanningAlertReopenedEvent : CodeScanningAlertEvent
{
    [JsonPropertyName("action")]
    public override string Action => CodeScanningAlertAction.Reopened;
}
