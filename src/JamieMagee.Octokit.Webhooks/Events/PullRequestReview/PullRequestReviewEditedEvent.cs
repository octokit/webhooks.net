namespace JamieMagee.Octokit.Webhooks.Events.PullRequestReview
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;
    using JamieMagee.Octokit.Webhooks.Models.PullRequestReviewEvent;

    [WebhookActionType(PullRequestReviewActionValue.Edited)]
    public sealed record PullRequestReviewEditedEvent : PullRequestReviewEvent
    {
        [JsonPropertyName("action")]
        public override string Action => PullRequestReviewAction.Edited;

        [JsonPropertyName("changes")]
        public Changes Changes { get; init; } = null!;
    }
}
