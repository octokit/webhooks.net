namespace JamieMagee.Octokit.Webhooks.Events.PullRequest
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    public sealed record PullRequestUnassignedEvent : PullRequestEvent
    {
        [JsonPropertyName("action")]
        public override string Action => PullRequestEventAction.Unassigned;

        [JsonPropertyName("assignee")]
        public User Assignee { get; set; } = null!;
    }
}
