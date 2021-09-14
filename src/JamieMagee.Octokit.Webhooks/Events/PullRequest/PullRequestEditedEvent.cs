namespace JamieMagee.Octokit.Webhooks.Events.PullRequest
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;
    using JamieMagee.Octokit.Webhooks.Models.PullRequestEvent;

    [WebhookActionType(PullRequestActionValue.Edited)]
    public sealed record PullRequestEditedEvent : PullRequestEvent
    {
        [JsonPropertyName("action")]
        public override string Action => PullRequestAction.Edited;

        [JsonPropertyName("changes")]
        public PullRequestEditedEventChanges Changes { get; init; } = null!;
    }
}
