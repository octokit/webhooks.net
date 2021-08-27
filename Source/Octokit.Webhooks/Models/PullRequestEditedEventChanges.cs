namespace Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;

    public class PullRequestEditedEventChanges
    {
        [JsonPropertyName("body")] public PullRequestEditedEventChangesBody? Body { get; set; }

        [JsonPropertyName("title")] public PullRequestEditedEventChangesTitle? Title { get; set; }
    }
}
