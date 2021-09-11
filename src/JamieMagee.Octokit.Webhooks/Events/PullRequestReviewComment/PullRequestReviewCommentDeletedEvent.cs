namespace JamieMagee.Octokit.Webhooks.Events.PullRequestReviewComment
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    public sealed record PullRequestReviewCommentDeletedEvent : PullRequestReviewCommentEvent
    {
        [JsonPropertyName("action")]
        public override string Action => PullRequestReviewCommentAction.Deleted;
    }
}
