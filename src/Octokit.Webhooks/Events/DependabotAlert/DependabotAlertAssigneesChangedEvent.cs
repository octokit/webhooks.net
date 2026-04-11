namespace Octokit.Webhooks.Events.DependabotAlert;

[PublicAPI]
[WebhookActionType(DependabotAlertActionValue.AssigneesChanged)]
public sealed record DependabotAlertAssigneesChangedEvent : DependabotAlertEvent
{
    [JsonPropertyName("action")]
    public override string Action => DependabotAlertAction.AssigneesChanged;
}
