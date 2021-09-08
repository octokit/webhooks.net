namespace JamieMagee.Octokit.Webhooks.Events.PullRequest
{
    using System.Text.Json.Serialization;

    public sealed record PullRequestReadyForReviewEvent : PullRequestEvent
    {
        [JsonPropertyName("action")]
        public override string Action => "ready_for_review";
    }
}
