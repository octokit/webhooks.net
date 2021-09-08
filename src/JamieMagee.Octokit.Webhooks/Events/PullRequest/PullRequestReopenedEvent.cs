namespace JamieMagee.Octokit.Webhooks.Events.PullRequest
{
    using System.Text.Json.Serialization;

    public class PullRequestReopenedEvent : PullRequestEvent
    {
        [JsonPropertyName("action")] public override string Action => "reopened";
    }
}
