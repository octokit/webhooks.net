namespace Octokit.Webhooks.Events.PullRequest;

[PublicAPI]
[WebhookActionType(PullRequestActionValue.Unlabeled)]
public sealed record PullRequestUnlabeledEvent : PullRequestEvent
{
    [JsonPropertyName("action")]
    public override string Action => PullRequestAction.Unlabeled;

    [JsonPropertyName("label")]
    public Label Label { get; init; } = null!;
}
