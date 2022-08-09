namespace Octokit.Webhooks.Events.PullRequest;

[PublicAPI]
[WebhookActionType(PullRequestActionValue.ConvertedToDraft)]
public sealed record PullRequestConvertedToDraftEvent : PullRequestEvent
{
    [JsonPropertyName("action")]
    public override string Action => PullRequestAction.ConvertedToDraft;
}
