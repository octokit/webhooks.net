namespace Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using Octokit.Webhooks.Converter;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.Deployment)]
    [JsonConverter(typeof(WebhookConverter<DeploymentEvent>))]
    public abstract record DeploymentEvent : WebhookEvent
    {
        [JsonPropertyName("deployment")]
        public Models.DeploymentEvent.Deployment Deployment { get; init; }
    }
}
