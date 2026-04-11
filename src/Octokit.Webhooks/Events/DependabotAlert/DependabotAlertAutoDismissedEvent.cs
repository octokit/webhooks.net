namespace Octokit.Webhooks.Events.DependabotAlert;

[PublicAPI]
[WebhookActionType(DependabotAlertActionValue.AutoDismissed)]
public sealed record DependabotAlertAutoDismissedEvent : DependabotAlertEvent
{
    [JsonPropertyName("action")]
    public override string Action => DependabotAlertAction.AutoDismissed;
}
