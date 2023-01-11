namespace Octokit.Webhooks.Events.DependabotAlert;

[PublicAPI]
[WebhookActionType(DependabotAlertActionValue.Reintroduced)]
public sealed record DependabotAlertReintroducedEvent : DependabotAlertEvent
{
    [JsonPropertyName("action")]
    public override string Action => DependabotAlertAction.Reintroduced;
}
