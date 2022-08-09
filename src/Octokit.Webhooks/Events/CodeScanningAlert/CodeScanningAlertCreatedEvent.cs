namespace Octokit.Webhooks.Events.CodeScanningAlert;

[PublicAPI]
[WebhookActionType(CodeScanningAlertActionValue.Created)]
public sealed record CodeScanningAlertCreatedEvent : CodeScanningAlertEvent
{
    [JsonPropertyName("action")]
    public override string Action => CodeScanningAlertAction.Created;
}
