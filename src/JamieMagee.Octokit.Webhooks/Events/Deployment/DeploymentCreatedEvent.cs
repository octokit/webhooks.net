namespace JamieMagee.Octokit.Webhooks.Events.Deployment
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    [WebhookActionType(DeploymentActionValue.Created)]
    public sealed record DeploymentCreatedEvent : DeploymentEvent
    {
        [JsonPropertyName("action")]
        public override string Action => DeploymentAction.Created;
    }
}
