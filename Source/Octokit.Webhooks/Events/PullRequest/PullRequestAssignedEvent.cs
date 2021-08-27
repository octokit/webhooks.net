namespace Octokit.Webhooks.Events.PullRequest
{
    using System.Text.Json.Serialization;
    using Models;

    public class PullRequestAssignedEvent : PullRequestEvent
    {
        [JsonPropertyName("action")] public override string Action => "assigned";

        [JsonPropertyName("assignee")] public User Assignee { get; set; } = null!;
    }
}
