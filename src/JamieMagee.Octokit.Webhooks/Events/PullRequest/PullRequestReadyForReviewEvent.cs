namespace JamieMagee.Octokit.Webhooks.Events.PullRequest
{
    using System.Text.Json.Serialization;

    [WebhookActionType(PullRequestActionValue.ReadyForReview)]
    public sealed record PullRequestReadyForReviewEvent : PullRequestEvent
    {
        [JsonPropertyName("action")]
        public override string Action => PullRequestAction.ReadyForReview;
    }
}
