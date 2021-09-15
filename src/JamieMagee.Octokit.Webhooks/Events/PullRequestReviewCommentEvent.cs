namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;
    using JamieMagee.Octokit.Webhooks.Models;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.PullRequestReviewComment)]
    [JsonConverter(typeof(WebhookConverter<PullRequestReviewCommentEvent>))]
    public abstract record PullRequestReviewCommentEvent : WebhookEvent
    {
        [JsonPropertyName("comment")]
        public Models.PullRequestReviewComment Comment { get; init; } = null!;

        [JsonPropertyName("pull_request")]
        public SimplePullRequest PullRequest { get; init; } = null!;
    }
}
