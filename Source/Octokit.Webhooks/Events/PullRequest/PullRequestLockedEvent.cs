namespace Octokit.Webhooks.Events.PullRequest
{
    using System.Text.Json.Serialization;

    public class PullRequestLockedEvent : PullRequestEvent
    {
        [JsonPropertyName("action")] public override string Action => "locked";
    }
}
