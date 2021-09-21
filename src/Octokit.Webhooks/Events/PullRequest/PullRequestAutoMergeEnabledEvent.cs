namespace Octokit.Webhooks.Events.PullRequest
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(PullRequestActionValue.AutoMergeEnabled)]
    public sealed record PullRequestAutoMergeEnabledEvent : PullRequestEvent
    {
        [JsonPropertyName("action")]
        public override string Action => PullRequestAction.AutoMergeEnabled;
    }
}
