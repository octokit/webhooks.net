namespace Octokit.Webhooks.Events.PullRequest;

[PublicAPI]
[WebhookActionType(PullRequestActionValue.Enqueued)]
public sealed record PullRequestEnqueuedEvent : PullRequestEvent
{
    [JsonPropertyName("action")]
    public override string Action => PullRequestAction.Enqueued;
}
