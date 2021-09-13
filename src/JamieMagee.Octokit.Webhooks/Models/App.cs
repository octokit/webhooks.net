namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public sealed record App
    {
        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("slug")]
        public string? Slug { get; init; }

        [JsonPropertyName("node_id")]
        public string NodeId { get; init; } = null!;

        [JsonPropertyName("owner")]
        public User Owner { get; init; } = null!;

        [JsonPropertyName("name")]
        public string Name { get; init; } = null!;

        [JsonPropertyName("description")]
        public string? Description { get; init; } = null!;

        [JsonPropertyName("external_url")]
        public string ExternalUrl { get; init; } = null!;

        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; init; } = null!;

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; init; } = null!;

        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; init; } = null!;

        [JsonPropertyName("permissions")]
        public AppPermissions? Permissions { get; init; }

        [JsonPropertyName("events")]
        public IEnumerable<AppEvent>? Events { get; init; }
    }
}
