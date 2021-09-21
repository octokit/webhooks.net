namespace Octokit.Webhooks.Events.PullRequestReview
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;
    using Octokit.Webhooks.Models.PullRequestReviewEvent;

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
