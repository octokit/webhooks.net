namespace Octokit.Webhooks.Events.PullRequest
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;
    using Octokit.Webhooks.Models;

    [PublicAPI]
    [WebhookActionType(PullRequestActionValue.Unlabeled)]
    public sealed record PullRequestUnlabeledEvent : PullRequestEvent
    {
        [JsonPropertyName("action")]
        public override string Action => PullRequestAction.Unlabeled;

        [JsonPropertyName("label")]
        public Label Label { get; init; } = null!;
    }
}
