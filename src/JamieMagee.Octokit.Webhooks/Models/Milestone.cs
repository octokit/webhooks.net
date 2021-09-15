namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record Milestone
    {
        [JsonPropertyName("url")]
        public string Url { get; init; } = null!;

        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; init; } = null!;

        [JsonPropertyName("labels_url")]
        public string LabelsUrl { get; init; } = null!;

        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("node_id")]
        public string NodeId { get; init; } = null!;

        [JsonPropertyName("number")]
        public int Number { get; init; }

        [JsonPropertyName("title")]
        public string Title { get; init; } = null!;

        [JsonPropertyName("description")]
        public string? Description { get; init; }

        [JsonPropertyName("creator")]
        public User Creator { get; init; } = null!;

        [JsonPropertyName("open_issues")]
        public int OpenIssues { get; init; }

        [JsonPropertyName("closed_issues")]
        public int ClosedIssues { get; init; }

        [JsonPropertyName("state")]
        public MilestoneState State { get; init; }

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; init; } = null!;

        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; init; } = null!;

        [JsonPropertyName("due_on")]
        public string? DueOn { get; init; }

        [JsonPropertyName("closed_at")]
        public string? ClosedAt { get; init; }
    }
}
