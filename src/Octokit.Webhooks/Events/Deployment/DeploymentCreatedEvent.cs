namespace Octokit.Webhooks.Events.Deployment;

[PublicAPI]
[WebhookActionType(DeploymentActionValue.Created)]
public sealed record DeploymentCreatedEvent : DeploymentEvent
{
    [JsonPropertyName("action")]
    public override string Action => DeploymentAction.Created;
}
