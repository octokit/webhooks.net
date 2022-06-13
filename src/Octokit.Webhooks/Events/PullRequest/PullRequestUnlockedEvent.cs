namespace Octokit.Webhooks.Events.PullRequest;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(PullRequestActionValue.Unlocked)]
public sealed record PullRequestUnlockedEvent : PullRequestEvent
{
    [JsonPropertyName("action")]
    public override string Action => PullRequestAction.Unlocked;
}