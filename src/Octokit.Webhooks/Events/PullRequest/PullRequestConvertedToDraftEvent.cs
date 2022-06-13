namespace Octokit.Webhooks.Events.PullRequest;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(PullRequestActionValue.ConvertedToDraft)]
public sealed record PullRequestConvertedToDraftEvent : PullRequestEvent
{
    [JsonPropertyName("action")]
    public override string Action => PullRequestAction.ConvertedToDraft;
}