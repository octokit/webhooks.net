namespace Octokit.Webhooks.Events.PullRequest;

[PublicAPI]
[WebhookActionType(PullRequestActionValue.Synchronize)]
public sealed record PullRequestSynchronizeEvent : PullRequestEvent
{
    [JsonPropertyName("action")]
    public override string Action => PullRequestAction.Synchronize;

    [JsonPropertyName("before")]
    public string Before { get; init; } = null!;

    [JsonPropertyName("after")]
    public string After { get; init; } = null!;
}
