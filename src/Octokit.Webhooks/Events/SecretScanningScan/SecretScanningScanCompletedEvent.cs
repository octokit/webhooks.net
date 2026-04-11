namespace Octokit.Webhooks.Events.SecretScanningScan;

[PublicAPI]
[WebhookActionType(SecretScanningScanActionValue.Completed)]
public sealed record SecretScanningScanCompletedEvent : SecretScanningScanEvent
{
    [JsonPropertyName("action")]
    public override string Action => SecretScanningScanAction.Completed;
}
