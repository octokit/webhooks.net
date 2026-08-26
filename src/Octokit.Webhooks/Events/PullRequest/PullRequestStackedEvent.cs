namespace Octokit.Webhooks.Events.PullRequest;

using Octokit.Webhooks.Models.PullRequestEvent;

[PublicAPI]
[WebhookActionType(PullRequestActionValue.Stacked)]
public sealed record PullRequestStackedEvent : PullRequestEvent
{
    [JsonPropertyName("action")]
    public override string Action => PullRequestAction.Stacked;

    [JsonPropertyName("stack")]
    public required PullRequestStack Stack { get; init; }
}
