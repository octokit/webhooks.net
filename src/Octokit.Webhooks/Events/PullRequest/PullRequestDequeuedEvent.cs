namespace Octokit.Webhooks.Events.PullRequest;

[PublicAPI]
[WebhookActionType(PullRequestActionValue.Dequeued)]
public sealed record PullRequestDequeuedEvent : PullRequestEvent
{
    [JsonPropertyName("action")]
    public override string Action => PullRequestAction.Dequeued;

    [JsonPropertyName("reason")]
    public string Reason { get; init; } = null!;
}
