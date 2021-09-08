namespace JamieMagee.Octokit.Webhooks.Events.PullRequest
{
    using System.Text.Json.Serialization;

    public class PullRequestOpenedEvent : PullRequestEvent
    {
        [JsonPropertyName("action")] public override string Action => "opened";
    }
}
