namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;

    public class PullRequestEditedEventChangesBody
    {
        [JsonPropertyName("from")]
        public string From { get; set; } = null!;
    }
}
