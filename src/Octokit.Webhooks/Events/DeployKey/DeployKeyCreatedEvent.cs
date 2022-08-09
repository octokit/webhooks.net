namespace Octokit.Webhooks.Events.DeployKey;

[PublicAPI]
[WebhookActionType(DeployKeyActionValue.Created)]
public sealed record DeployKeyCreatedEvent : DeployKeyEvent
{
    [JsonPropertyName("action")]
    public override string Action => DeployKeyAction.Created;
}
