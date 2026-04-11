namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.PullRequestReviewComment)]
[JsonConverter(typeof(WebhookConverter<PullRequestReviewCommentEvent>))]
public abstract record PullRequestReviewCommentEvent : WebhookEvent
{
    [JsonPropertyName("comment")]
    public required Models.PullRequestReviewComment Comment { get; init; }

    [JsonPropertyName("pull_request")]
    public required SimplePullRequest PullRequest { get; init; }
}
