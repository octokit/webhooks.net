namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record DiscussionCategory
    {
        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("repository_id")]
        public int RepositoryId { get; init; }

        [JsonPropertyName("emoji")]
        public string Emoji { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonPropertyName("description")]
        public string Description { get; init; }

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; init; }

        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; init; }

        [JsonPropertyName("slug")]
        public string Slug { get; init; }

        [JsonPropertyName("is_answerable")]
        public int IsAnswerable { get; init; }
    }
}
