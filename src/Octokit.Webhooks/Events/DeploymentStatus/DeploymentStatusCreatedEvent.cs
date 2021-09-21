namespace Octokit.Webhooks.Events.DeploymentStatus
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(DeploymentStatusActionValue.Created)]
    public sealed record DeploymentStatusCreatedEvent : DeploymentStatusEvent
    {
        [JsonPropertyName("action")]
        public override string Action => DeploymentStatusAction.Created;
    }
}
