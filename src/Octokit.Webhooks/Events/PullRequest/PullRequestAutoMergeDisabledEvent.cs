namespace Octokit.Webhooks.Events.PullRequest;

[PublicAPI]
[WebhookActionType(PullRequestActionValue.AutoMergeDisabled)]
public sealed record PullRequestAutoMergeDisabledEvent : PullRequestEvent
{
    [JsonPropertyName("action")]
    public override string Action => PullRequestAction.AutoMergeDisabled;
}
