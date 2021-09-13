namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;

    public sealed record PullRequestEditedEventChanges
    {
        [JsonPropertyName("body")]
        public PullRequestEditedEventChangesBody? Body { get; set; }

        [JsonPropertyName("title")]
        public PullRequestEditedEventChangesTitle? Title { get; set; }
    }
}
