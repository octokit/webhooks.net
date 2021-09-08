namespace JamieMagee.Octokit.Webhooks.Events.PullRequest
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    public sealed record PullRequestLabeledEvent : PullRequestEvent
    {
        [JsonPropertyName("action")]
        public override string Action => "labeled";

        [JsonPropertyName("label")]
        public Label Label { get; set; } = null!;
    }
}
