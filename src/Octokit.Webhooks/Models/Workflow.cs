namespace Octokit.Webhooks.Models
{
    using System;
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;
    using Octokit.Webhooks.Converter;

    [PublicAPI]
    public sealed record Workflow
    {
        [JsonPropertyName("badge_url")]
        public string BadgeUrl { get; init; } = null!;

        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(DateTimeOffsetConverter))]
        public DateTimeOffset CreatedAt { get; init; }

        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; init; } = null!;

        [JsonPropertyName("id")]
        public long Id { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; } = null!;

        [JsonPropertyName("node_id")]
        public string NodeId { get; init; } = null!;

        [JsonPropertyName("path")]
        public string Path { get; init; } = null!;

        [JsonPropertyName("state")]
        public string State { get; init; } = null!;

        [JsonPropertyName("updated_at")]
        [JsonConverter(typeof(DateTimeOffsetConverter))]
        public DateTimeOffset UpdatedAt { get; init; }

        [JsonPropertyName("url")]
        public string Url { get; init; } = null!;
    }
}
