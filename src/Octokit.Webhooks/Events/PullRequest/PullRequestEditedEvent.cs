namespace Octokit.Webhooks.Events.PullRequest
{
    using System.Text.Json.Serialization;
    using Octokit.Webhooks.Models.PullRequestEvent;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(PullRequestActionValue.Edited)]
    public sealed record PullRequestEditedEvent : PullRequestEvent
    {
        [JsonPropertyName("action")]
        public override string Action => PullRequestAction.Edited;

        [JsonPropertyName("changes")]
        public PullRequestEditedEventChanges Changes { get; init; } = null!;
    }
}
