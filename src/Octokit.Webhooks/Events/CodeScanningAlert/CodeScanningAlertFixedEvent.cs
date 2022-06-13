namespace Octokit.Webhooks.Events.CodeScanningAlert;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(CodeScanningAlertActionValue.Fixed)]
public sealed record CodeScanningAlertFixedEvent : CodeScanningAlertEvent
{
    [JsonPropertyName("action")]
    public override string Action => CodeScanningAlertAction.Fixed;
}