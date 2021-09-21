namespace Octokit.Webhooks.Events.PullRequestReviewComment
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(PullRequestReviewCommentActionValue.Created)]
    public sealed record PullRequestReviewCommentCreatedEvent : PullRequestReviewCommentEvent
    {
        [JsonPropertyName("action")]
        public override string Action => PullRequestReviewCommentAction.Created;
    }
}
