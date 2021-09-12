namespace JamieMagee.Octokit.Webhooks.Events.PullRequest
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    public sealed record PullRequestReviewRequestedEvent : PullRequestEvent
    {
        [JsonPropertyName("action")]
        public override string Action => PullRequestAction.ReviewRequested;

        [JsonPropertyName("requested_reviewer")]
        public User? RequestedReviewer { get; init; }

        [JsonPropertyName("requested_team")]
        public Team? RequestedTeam { get; init; }
    }
}
