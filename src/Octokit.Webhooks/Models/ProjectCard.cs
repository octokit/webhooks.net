namespace Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record ProjectCard
    {
        [JsonPropertyName("url")]
        public string Url { get; init; } = null!;

        [JsonPropertyName("project_url")]
        public string ProjectUrl { get; init; } = null!;

        [JsonPropertyName("column_url")]
        public string ColumnUrl { get; init; } = null!;

        [JsonPropertyName("column_id")]
        public int ColumnId { get; init; }

        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("node_id")]
        public string NodeId { get; init; } = null!;

        [JsonPropertyName("note")]
        public string? Note { get; init; }

        [JsonPropertyName("archived")]
        public int Archived { get; init; }

        [JsonPropertyName("creator")]
        public User Creator { get; init; } = null!;

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; init; } = null!;

        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; init; } = null!;

        [JsonPropertyName("content_url")]
        public string? ContentUrl { get; init; }

        [JsonPropertyName("after_id")]
        public int AfterId { get; init; }
    }
}
