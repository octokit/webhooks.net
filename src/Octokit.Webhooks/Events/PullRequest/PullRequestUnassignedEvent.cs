namespace Octokit.Webhooks.Events.PullRequest
{
    using System.Text.Json.Serialization;
    using Octokit.Webhooks.Models;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(PullRequestActionValue.Unassigned)]
    public sealed record PullRequestUnassignedEvent : PullRequestEvent
    {
        [JsonPropertyName("action")]
        public override string Action => PullRequestAction.Unassigned;

        [JsonPropertyName("assignee")]
        public User Assignee { get; init; } = null!;
    }
}
