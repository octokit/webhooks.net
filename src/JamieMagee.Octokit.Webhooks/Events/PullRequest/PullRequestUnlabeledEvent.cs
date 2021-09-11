namespace JamieMagee.Octokit.Webhooks.Events.PullRequest
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    public sealed record PullRequestUnlabeledEvent : PullRequestEvent
    {
        [JsonPropertyName("action")]
        public override string Action => PullRequestEventAction.Unlabeled;

        [JsonPropertyName("label")]
        public Label Label { get; set; } = null!;
    }
}
