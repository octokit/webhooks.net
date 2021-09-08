namespace JamieMagee.Octokit.Webhooks.Events.PullRequest
{
    using System.Text.Json.Serialization;

    public sealed record PullRequestAutoMergeEnabledEvent : PullRequestEvent
    {
        [JsonPropertyName("action")]
        public override string Action => "auto_merge_enabled";
    }
}
