namespace JamieMagee.Octokit.Webhooks.Events.PullRequestReview
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    public sealed record PullRequestReviewEditedEvent : PullRequestReviewEvent
    {
        [JsonPropertyName("action")]
        public override string Action => PullRequestReviewAction.Edited;
    }
}
