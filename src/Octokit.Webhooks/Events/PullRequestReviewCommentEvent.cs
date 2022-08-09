namespace Octokit.Webhooks.Events;

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
