namespace Octokit.Webhooks.Events.PullRequestReview
{
    using System.Text.Json.Serialization;
    using Octokit.Webhooks.Models.PullRequestReviewEvent;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(PullRequestReviewActionValue.Edited)]
    public sealed record PullRequestReviewEditedEvent : PullRequestReviewEvent
    {
        [JsonPropertyName("action")]
        public override string Action => PullRequestReviewAction.Edited;

        [JsonPropertyName("changes")]
        public Changes Changes { get; init; } = null!;
    }
}
