namespace Octokit.Webhooks.Models
{
    using System;
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;
    using Octokit.Webhooks.Converter;

    [PublicAPI]
    public sealed record DiscussionCategory
    {
        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("repository_id")]
        public int RepositoryId { get; init; }

        [JsonPropertyName("emoji")]
        public string Emoji { get; init; } = null!;

        [JsonPropertyName("name")]
        public string Name { get; init; } = null!;

        [JsonPropertyName("description")]
        public string Description { get; init; } = null!;

        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(DateTimeOffsetConverter))]
        public DateTimeOffset CreatedAt { get; init; }

        [JsonPropertyName("updated_at")]
        [JsonConverter(typeof(DateTimeOffsetConverter))]
        public DateTimeOffset UpdatedAt { get; init; }

        [JsonPropertyName("slug")]
        public string Slug { get; init; } = null!;

        [JsonPropertyName("is_answerable")]
        public int IsAnswerable { get; init; }
    }
}
