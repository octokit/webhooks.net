namespace Octokit.Webhooks.Events.PullRequest
{
    using System.Text.Json.Serialization;
    using Octokit.Webhooks.Models;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(PullRequestActionValue.Assigned)]
    public sealed record PullRequestAssignedEvent : PullRequestEvent
    {
        [JsonPropertyName("action")]
        public override string Action => PullRequestAction.Assigned;

        [JsonPropertyName("assignee")]
        public User Assignee { get; init; } = null!;
    }
}
