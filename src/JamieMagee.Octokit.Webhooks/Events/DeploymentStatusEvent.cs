namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.DeploymentStatus)]
    [JsonConverter(typeof(WebhookConverter<DeploymentStatusEvent>))]
    public abstract record DeploymentStatusEvent : WebhookEvent
    {
        [JsonPropertyName("deployment_status")]
        public Models.DeploymentStatusEvent.DeploymentStatus DeploymentStatus { get; init; } = null!;

        [JsonPropertyName("deployment")]
        public Models.DeploymentStatusEvent.Deployment Deployment { get; init; } = null!;
    }
}
