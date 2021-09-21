namespace Octokit.Webhooks.Events.PullRequestReviewComment
{
    using System.Text.Json.Serialization;
    using Octokit.Webhooks.Models.PullRequestReviewCommentEvent;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(PullRequestReviewCommentActionValue.Edited)]
    public sealed record PullRequestReviewCommentEditedEvent : PullRequestReviewCommentEvent
    {
        [JsonPropertyName("action")]
        public override string Action => PullRequestReviewCommentAction.Edited;

        [JsonPropertyName("changes")]
        public Changes Changes { get; init; } = null!;
    }
}
