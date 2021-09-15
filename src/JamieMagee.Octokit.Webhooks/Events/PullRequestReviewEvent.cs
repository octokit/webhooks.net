namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;
    using JamieMagee.Octokit.Webhooks.Models;
    using JamieMagee.Octokit.Webhooks.Models.PullRequestReviewEvent;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.PullRequestReview)]
    [JsonConverter(typeof(WebhookConverter<PullRequestReviewEvent>))]
    public abstract record PullRequestReviewEvent : WebhookEvent
    {
        [JsonPropertyName("review")]
        public Review Review { get; init; } = null!;

        [JsonPropertyName("pull_request")]
        public SimplePullRequest PullRequest { get; init; } = null!;
    }
}
