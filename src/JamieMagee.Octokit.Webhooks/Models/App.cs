namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public sealed record App
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("slug")]
        public string? Slug { get; set; }

        [JsonPropertyName("node_id")]
        public string NodeId { get; set; } = null!;

        [JsonPropertyName("owner")]
        public User Owner { get; set; } = null!;

        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("description")]
        public string? Description { get; set; } = null!;

        [JsonPropertyName("external_url")]
        public string ExternalUrl { get; set; } = null!;

        [JsonPropertyName("html_url")]
        public string HtmlUrl { get; set; } = null!;

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; set; } = null!;

        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; set; } = null!;

        [JsonPropertyName("permissions")]
        public AppPermissions? Permissions { get; set; }

        [JsonPropertyName("events")]
        public IEnumerable<AppEvent>? Events { get; set; }
    }
}
