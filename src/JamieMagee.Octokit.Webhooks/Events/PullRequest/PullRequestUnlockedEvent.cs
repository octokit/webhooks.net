namespace Octokit.Webhooks.Events.PullRequest
{
    using System.Text.Json.Serialization;

    public class PullRequestUnlockedEvent : PullRequestEvent
    {
        [JsonPropertyName("action")] public override string Action => "unlocked";
    }
}
