namespace JamieMagee.Octokit.Webhooks.Events.PullRequest
{
    using System.Text.Json.Serialization;

    [WebhookActionType(PullRequestActionValue.AutoMergeDisabled)]
    public sealed record PullRequestAutoMergeDisabledEvent : PullRequestEvent
    {
        [JsonPropertyName("action")]
        public override string Action => PullRequestAction.AutoMergeDisabled;
    }
}
