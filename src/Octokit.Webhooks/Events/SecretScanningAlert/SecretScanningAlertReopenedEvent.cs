namespace Octokit.Webhooks.Events.SecretScanningAlert;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(SecretScanningAlertActionValue.Reopened)]
public sealed record SecretScanningAlertReopenedEvent : SecretScanningAlertEvent
{
    [JsonPropertyName("action")]
    public override string Action => SecretScanningAlertAction.Reopened;
}