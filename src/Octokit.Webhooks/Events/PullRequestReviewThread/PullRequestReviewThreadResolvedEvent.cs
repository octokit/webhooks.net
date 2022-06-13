namespace Octokit.Webhooks.Events.PullRequestReviewThread;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(PullRequestReviewThreadActionValue.Resolved)]
public sealed record PullRequestReviewThreadResolvedEvent : PullRequestReviewThreadEvent
{
    [JsonPropertyName("action")]
    public override string Action => PullRequestReviewThreadActionValue.Resolved;
}
