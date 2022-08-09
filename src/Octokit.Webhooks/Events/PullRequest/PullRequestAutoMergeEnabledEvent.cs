namespace Octokit.Webhooks.Events.PullRequest;

[PublicAPI]
[WebhookActionType(PullRequestActionValue.AutoMergeEnabled)]
public sealed record PullRequestAutoMergeEnabledEvent : PullRequestEvent
{
    [JsonPropertyName("action")]
    public override string Action => PullRequestAction.AutoMergeEnabled;
}
