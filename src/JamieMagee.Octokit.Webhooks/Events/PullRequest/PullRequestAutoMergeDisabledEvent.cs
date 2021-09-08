namespace JamieMagee.Octokit.Webhooks.Events.PullRequest
{
    using System.Text.Json.Serialization;

    public class PullRequestAutoMergeDisabledEvent : PullRequestEvent
    {
        [JsonPropertyName("action")] public override string Action => "auto_merge_disabled";
    }
}
