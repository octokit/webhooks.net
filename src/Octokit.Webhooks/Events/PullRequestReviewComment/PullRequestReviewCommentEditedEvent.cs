namespace Octokit.Webhooks.Events.PullRequestReviewComment;

using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Models.PullRequestReviewCommentEvent;

[PublicAPI]
[WebhookActionType(PullRequestReviewCommentActionValue.Edited)]
public sealed record PullRequestReviewCommentEditedEvent : PullRequestReviewCommentEvent
{
    [JsonPropertyName("action")]
    public override string Action => PullRequestReviewCommentAction.Edited;

    [JsonPropertyName("changes")]
    public Changes Changes { get; init; } = null!;
}
