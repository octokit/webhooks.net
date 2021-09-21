namespace Octokit.Webhooks.Events.PullRequest
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(PullRequestActionValue.ReadyForReview)]
    public sealed record PullRequestReadyForReviewEvent : PullRequestEvent
    {
        [JsonPropertyName("action")]
        public override string Action => PullRequestAction.ReadyForReview;
    }
}
