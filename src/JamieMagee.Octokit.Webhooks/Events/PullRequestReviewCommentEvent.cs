namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;

    [WebhookEventType(WebhookEventType.PullRequestReviewComment)]
    [JsonConverter(typeof(WebhookConverter<PullRequestReviewCommentEvent>))]
    public abstract record PullRequestReviewCommentEvent : WebhookEvent
    {
    }
}
