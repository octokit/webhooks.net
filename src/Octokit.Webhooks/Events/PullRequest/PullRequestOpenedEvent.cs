namespace Octokit.Webhooks.Events.PullRequest
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(PullRequestActionValue.Opened)]
    public sealed record PullRequestOpenedEvent : PullRequestEvent
    {
        [JsonPropertyName("action")]
        public override string Action => PullRequestAction.Opened;
    }
}
