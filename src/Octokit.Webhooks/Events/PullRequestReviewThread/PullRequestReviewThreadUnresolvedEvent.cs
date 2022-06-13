namespace Octokit.Webhooks.Events.PullRequestReviewThread;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(PullRequestReviewThreadActionValue.Unresolved)]
public sealed record PullRequestReviewThreadUnresolvedEvent : PullRequestReviewThreadEvent
{
    [JsonPropertyName("action")]
    public override string Action => PullRequestReviewThreadActionValue.Unresolved;
}
