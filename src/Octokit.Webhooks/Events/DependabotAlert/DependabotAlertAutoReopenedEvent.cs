namespace Octokit.Webhooks.Events.DependabotAlert;

[PublicAPI]
[WebhookActionType(DependabotAlertActionValue.AutoReopened)]
public sealed record DependabotAlertAutoReopenedEvent : DependabotAlertEvent
{
    [JsonPropertyName("action")]
    public override string Action => DependabotAlertAction.AutoReopened;
}
