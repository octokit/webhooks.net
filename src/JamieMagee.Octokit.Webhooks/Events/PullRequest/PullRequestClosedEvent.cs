namespace Octokit.Webhooks.Events.PullRequest
{
    using System.Text.Json.Serialization;

    public class PullRequestClosedEvent : PullRequestEvent
    {
        [JsonPropertyName("action")] public override string Action => "closed";
    }
}
