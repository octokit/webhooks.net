namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;

    [WebhookEventType(WebhookEventType.DeploymentStatus)]
    [JsonConverter(typeof(WebhookConverter<DeploymentStatusEvent>))]
    public abstract record DeploymentStatusEvent : WebhookEvent
    {
    }
}
