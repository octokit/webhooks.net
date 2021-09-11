namespace JamieMagee.Octokit.Webhooks.Events.DeploymentStatus
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    public sealed record DeploymentStatusCreatedEvent : DeploymentStatusEvent
    {
        [JsonPropertyName("action")]
        public override string Action => DeploymentStatusAction.Created;
    }
}
