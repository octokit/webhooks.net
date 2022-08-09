namespace Octokit.Webhooks.Events.DeploymentStatus;

[PublicAPI]
[WebhookActionType(DeploymentStatusActionValue.Created)]
public sealed record DeploymentStatusCreatedEvent : DeploymentStatusEvent
{
    [JsonPropertyName("action")]
    public override string Action => DeploymentStatusAction.Created;
}
