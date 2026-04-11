namespace Octokit.Webhooks.Events;

using Octokit.Webhooks.Models.PullRequestReviewEvent;

[PublicAPI]
[WebhookEventType(WebhookEventType.PullRequestReviewThread)]
[JsonConverter(typeof(WebhookConverter<PullRequestReviewThreadEvent>))]
public abstract record PullRequestReviewThreadEvent : WebhookEvent
{
    [JsonPropertyName("review")]
    public Review? Review { get; init; }

    [JsonPropertyName("pull_request")]
    public required SimplePullRequest PullRequest { get; init; }
}
