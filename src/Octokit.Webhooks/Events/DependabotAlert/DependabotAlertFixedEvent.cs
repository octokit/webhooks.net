namespace Octokit.Webhooks.Events.DependabotAlert;

[PublicAPI]
[WebhookActionType(DependabotAlertActionValue.Fixed)]
public sealed record DependabotAlertFixedEvent : DependabotAlertEvent
{
    [JsonPropertyName("action")]
    public override string Action => DependabotAlertAction.Fixed;
}
