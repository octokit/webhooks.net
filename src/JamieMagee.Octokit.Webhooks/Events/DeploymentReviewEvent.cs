namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;

    [WebhookEventType(WebhookEventType.DeploymentReview)]
    [JsonConverter(typeof(WebhookConverter<DeploymentReviewEvent>))]
    public abstract record DeploymentReviewEvent : WebhookEvent
    {
    }
}
