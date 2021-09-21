namespace Octokit.Webhooks.Events.PullRequest
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;
    using Octokit.Webhooks.Models;

    [PublicAPI]
    [WebhookActionType(PullRequestActionValue.Labeled)]
    public sealed record PullRequestLabeledEvent : PullRequestEvent
    {
        [JsonPropertyName("action")]
        public override string Action => PullRequestAction.Labeled;

        [JsonPropertyName("label")]
        public Label Label { get; init; } = null!;
    }
}
