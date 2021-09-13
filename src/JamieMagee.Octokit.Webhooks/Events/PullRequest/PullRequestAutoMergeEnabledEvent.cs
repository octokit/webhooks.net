namespace JamieMagee.Octokit.Webhooks.Events.PullRequest
{
    using System.Text.Json.Serialization;

    [WebhookActionType(PullRequestActionValue.AutoMergeEnabled)]
    public sealed record PullRequestAutoMergeEnabledEvent : PullRequestEvent
    {
        [JsonPropertyName("action")]
        public override string Action => PullRequestAction.AutoMergeEnabled;
    }
}
