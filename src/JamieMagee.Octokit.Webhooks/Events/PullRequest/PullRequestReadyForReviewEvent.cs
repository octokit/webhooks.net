namespace JamieMagee.Octokit.Webhooks.Events.PullRequest
{
    using System.Text.Json.Serialization;

    public class PullRequestReadyForReviewEvent : PullRequestEvent
    {
        [JsonPropertyName("action")] public override string Action => "ready_for_review";
    }
}
