namespace Octokit.Webhooks.Events.PullRequest
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(PullRequestActionValue.Locked)]
    public sealed record PullRequestLockedEvent : PullRequestEvent
    {
        [JsonPropertyName("action")]
        public override string Action => PullRequestAction.Locked;
    }
}
