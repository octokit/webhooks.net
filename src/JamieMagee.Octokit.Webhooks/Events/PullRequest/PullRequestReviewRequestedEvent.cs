namespace JamieMagee.Octokit.Webhooks.Events.PullRequest
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    public sealed record PullRequestReviewRequestedEvent : PullRequestEvent
    {
        [JsonPropertyName("action")]
        public override string Action => "review_requested";

        [JsonPropertyName("requested_reviewer")]
        public User? RequestedReviewer { get; set; }

        [JsonPropertyName("requested_team")]
        public Team? RequestedTeam { get; set; }
    }
}
