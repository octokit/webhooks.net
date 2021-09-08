namespace JamieMagee.Octokit.Webhooks.Events.PullRequest
{
    using System.Text.Json.Serialization;
    using Models;

    public class PullRequestUnassignedEvent : PullRequestEvent
    {
        [JsonPropertyName("action")] public override string Action => "unassigned";

        [JsonPropertyName("assignee")] public User Assignee { get; set; } = null!;
    }
}
