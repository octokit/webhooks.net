namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;

    [WebhookEventType(WebhookEventType.PullRequestReview)]
    [JsonConverter(typeof(WebhookConverter<PullRequestReviewEvent>))]
    public abstract record PullRequestReviewEvent : WebhookEvent
    {
    }
}
