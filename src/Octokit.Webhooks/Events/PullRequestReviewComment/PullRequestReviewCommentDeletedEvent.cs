namespace Octokit.Webhooks.Events.PullRequestReviewComment;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(PullRequestReviewCommentActionValue.Deleted)]
public sealed record PullRequestReviewCommentDeletedEvent : PullRequestReviewCommentEvent
{
    [JsonPropertyName("action")]
    public override string Action => PullRequestReviewCommentAction.Deleted;
}