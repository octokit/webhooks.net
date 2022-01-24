namespace Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record DiscussionCategory
    {
        [JsonPropertyName("id")]
        public long Id { get; init; }

        [JsonPropertyName("repository_id")]
        public long RepositoryId { get; init; }

        [JsonPropertyName("emoji")]
        public string Emoji { get; init; } = null!;

        [JsonPropertyName("name")]
        public string Name { get; init; } = null!;

        [JsonPropertyName("description")]
        public string Description { get; init; } = null!;

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; init; } = null!;

        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; init; } = null!;

        [JsonPropertyName("slug")]
        public string Slug { get; init; } = null!;

        [JsonPropertyName("is_answerable")]
        public long IsAnswerable { get; init; }
    }
}
