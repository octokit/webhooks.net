namespace JamieMagee.Octokit.Webhooks.Events.PullRequest
{
    using System.Text.Json.Serialization;

    public class PullRequestAutoMergeEnabledEvent : PullRequestEvent
    {
        [JsonPropertyName("action")] public override string Action => "auto_merge_enabled";
    }
}
