namespace Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;

    public class PullRequestEditedEventChangesTitle
    {
        [JsonPropertyName("from")] public string From { get; set; } = null!;
    }
}
