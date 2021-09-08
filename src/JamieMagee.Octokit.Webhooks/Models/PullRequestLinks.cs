namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;

    public class PullRequestLinks
    {
        [JsonPropertyName("self")] public Link Self { get; set; } = null!;

        [JsonPropertyName("html")] public Link Html { get; set; } = null!;

        [JsonPropertyName("issue")] public Link Issue { get; set; } = null!;

        [JsonPropertyName("comments")] public Link Comments { get; set; } = null!;

        [JsonPropertyName("review_comments")] public Link ReviewComments { get; set; } = null!;

        [JsonPropertyName("review_comment")] public Link ReviewComment { get; set; } = null!;

        [JsonPropertyName("commits")] public Link Commits { get; set; } = null!;

        [JsonPropertyName("statuses")] public Link Statuses { get; set; } = null!;
    }
}
