namespace JamieMagee.Octokit.Webhooks.Events.PullRequestReview
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    public sealed record PullRequestReviewSubmittedEvent : PullRequestReviewEvent
    {
        [JsonPropertyName("action")]
        public override string Action => PullRequestReviewAction.Submitted;
    }
}
