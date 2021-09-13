namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;

    public sealed record PullRequestEditedEventChangesTitle
    {
        [JsonPropertyName("from")]
        public string From { get; set; } = null!;
    }
}
