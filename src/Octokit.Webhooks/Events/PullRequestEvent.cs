namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.PullRequest)]
[JsonConverter(typeof(WebhookConverter<PullRequestEvent>))]
public abstract record PullRequestEvent : WebhookEvent
{
    [JsonPropertyName("number")]
    public long Number { get; init; }

    [JsonPropertyName("pull_request")]
    public Models.PullRequestEvent.PullRequest PullRequest { get; init; } = null!;
}
