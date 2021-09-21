namespace Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;
    using Octokit.Webhooks.Converter;

    // TODO: Undocumented event
    [PublicAPI]
    [WebhookEventType(WebhookEventType.DeploymentReview)]
    [JsonConverter(typeof(WebhookConverter<DeploymentReviewEvent>))]
    public abstract record DeploymentReviewEvent : WebhookEvent;
}
