namespace JamieMagee.Octokit.Webhooks.Events.PullRequest
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    public sealed record PullRequestAssignedEvent : PullRequestEvent
    {
        [JsonPropertyName("action")]
        public override string Action => "assigned";

        [JsonPropertyName("assignee")]
        public User Assignee { get; set; } = null!;
    }
}
