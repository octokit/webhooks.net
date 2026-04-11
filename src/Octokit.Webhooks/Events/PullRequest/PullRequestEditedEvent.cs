namespace Octokit.Webhooks.Events.PullRequest;

using Octokit.Webhooks.Models.PullRequestEvent;

[PublicAPI]
[WebhookActionType(PullRequestActionValue.Edited)]
public sealed record PullRequestEditedEvent : PullRequestEvent
{
    [JsonPropertyName("action")]
    public override string Action => PullRequestAction.Edited;

    [JsonPropertyName("changes")]
    public required PullRequestEditedEventChanges Changes { get; init; }
}
