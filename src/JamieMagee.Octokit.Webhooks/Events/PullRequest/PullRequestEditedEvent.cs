namespace JamieMagee.Octokit.Webhooks.Events.PullRequest
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    public sealed record PullRequestEditedEvent : PullRequestEvent
    {
        [JsonPropertyName("action")]
        public override string Action => "edited";

        [JsonPropertyName("changes")]
        public PullRequestEditedEventChanges Changes { get; set; } = null!;
    }
}
