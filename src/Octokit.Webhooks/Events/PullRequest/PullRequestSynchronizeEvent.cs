namespace Octokit.Webhooks.Events.PullRequest;

[PublicAPI]
[WebhookActionType(PullRequestActionValue.Synchronize)]
public sealed record PullRequestSynchronizeEvent : PullRequestEvent
{
    [JsonPropertyName("action")]
    public override string Action => PullRequestAction.Synchronize;

    [JsonPropertyName("before")]
    public required string Before { get; init; }

    [JsonPropertyName("after")]
    public required string After { get; init; }
}
