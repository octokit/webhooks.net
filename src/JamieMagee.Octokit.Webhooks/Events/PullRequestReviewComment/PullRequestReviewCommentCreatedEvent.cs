namespace JamieMagee.Octokit.Webhooks.Events.PullRequestReviewComment
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    [WebhookActionType(PullRequestReviewCommentActionValue.Created)]
    public sealed record PullRequestReviewCommentCreatedEvent : PullRequestReviewCommentEvent
    {
        [JsonPropertyName("action")]
        public override string Action => PullRequestReviewCommentAction.Created;
    }
}
