namespace Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using Octokit.Webhooks.Converter;
    using JetBrains.Annotations;

    // TODO: Undocumented event

    [PublicAPI]
    [WebhookEventType(WebhookEventType.DeploymentReview)]
    [JsonConverter(typeof(WebhookConverter<DeploymentReviewEvent>))]
    public abstract record DeploymentReviewEvent : WebhookEvent;
}
