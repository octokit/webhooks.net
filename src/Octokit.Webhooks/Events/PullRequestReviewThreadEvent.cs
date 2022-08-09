namespace Octokit.Webhooks.Events;

using Octokit.Webhooks.Models.PullRequestReviewEvent;

[PublicAPI]
[WebhookEventType(WebhookEventType.PullRequestReviewThread)]
[JsonConverter(typeof(WebhookConverter<PullRequestReviewThreadEvent>))]
public abstract record PullRequestReviewThreadEvent : WebhookEvent
{
    [JsonPropertyName("review")]
    public Review Review { get; init; } = null!;

    [JsonPropertyName("pull_request")]
    public SimplePullRequest PullRequest { get; init; } = null!;
}
