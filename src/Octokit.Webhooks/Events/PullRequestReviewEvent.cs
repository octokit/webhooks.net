namespace Octokit.Webhooks.Events;

using Octokit.Webhooks.Models.PullRequestReviewEvent;

[PublicAPI]
[WebhookEventType(WebhookEventType.PullRequestReview)]
[JsonConverter(typeof(WebhookConverter<PullRequestReviewEvent>))]
public abstract record PullRequestReviewEvent : WebhookEvent
{
    [JsonPropertyName("review")]
    public required Review Review { get; init; }

    [JsonPropertyName("pull_request")]
    public required SimplePullRequest PullRequest { get; init; }
}
