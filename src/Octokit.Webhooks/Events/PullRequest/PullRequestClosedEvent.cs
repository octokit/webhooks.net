namespace Octokit.Webhooks.Events.PullRequest;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(PullRequestActionValue.Closed)]
public sealed record PullRequestClosedEvent : PullRequestEvent
{
    [JsonPropertyName("action")]
    public override string Action => PullRequestAction.Closed;
}
