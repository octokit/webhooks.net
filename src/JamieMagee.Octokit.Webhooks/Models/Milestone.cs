namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;

    public class Milestone
    {
        [JsonPropertyName("url")]
        public string Url { get; set; } = null!;

        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; set; } = null!;

        [JsonPropertyName("labels_url")]
        public string LabelsUrl { get; set; } = null!;

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("node_id")]
        public string NodeId { get; set; } = null!;

        [JsonPropertyName("number")]
        public int Number { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; } = null!;

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("creator")]
        public User Creator { get; set; } = null!;

        [JsonPropertyName("open_issues")]
        public int OpenIssues { get; set; }

        [JsonPropertyName("closed_issues")]
        public int ClosedIssues { get; set; }

        [JsonPropertyName("state")]
        public MilestoneState State { get; set; }

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; set; } = null!;

        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; set; } = null!;

        [JsonPropertyName("due_on")]
        public string? DueOn { get; set; }

        [JsonPropertyName("closed_at")]
        public string? ClosedAt { get; set; }
    }
}
