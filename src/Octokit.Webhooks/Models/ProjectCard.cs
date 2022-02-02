namespace Octokit.Webhooks.Models
{
    using System;
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;
    using Octokit.Webhooks.Converter;

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
        public long ColumnId { get; init; }

        [JsonPropertyName("id")]
        public long Id { get; init; }

        [JsonPropertyName("node_id")]
        public string NodeId { get; init; } = null!;

        [JsonPropertyName("note")]
        public string? Note { get; init; }

        [JsonPropertyName("archived")]
        public bool Archived { get; init; }

        [JsonPropertyName("creator")]
        public User Creator { get; init; } = null!;

        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(DateTimeOffsetConverter))]
        public DateTimeOffset CreatedAt { get; init; }

        [JsonPropertyName("updated_at")]
        [JsonConverter(typeof(DateTimeOffsetConverter))]
        public DateTimeOffset UpdatedAt { get; init; }

        [JsonPropertyName("content_url")]
        public string? ContentUrl { get; init; }

        [JsonPropertyName("after_id")]
        public long? AfterId { get; init; }
    }
}
