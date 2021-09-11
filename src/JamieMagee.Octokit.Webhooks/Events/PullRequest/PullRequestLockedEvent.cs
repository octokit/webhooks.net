namespace JamieMagee.Octokit.Webhooks.Events.PullRequest
{
    using System.Text.Json.Serialization;

    public sealed record PullRequestLockedEvent : PullRequestEvent
    {
        [JsonPropertyName("action")]
        public override string Action => PullRequestEventAction.Locked;
    }
}
