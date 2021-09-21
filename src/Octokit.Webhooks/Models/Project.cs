namespace Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record Project
    {
        [JsonPropertyName("owner_url")]
        public string owner_url { get; init; } = null!;

        [JsonPropertyName("url")]
        public string url { get; init; } = null!;

        [JsonPropertyName("html_url")]
        public string html_url { get; init; } = null!;

        [JsonPropertyName("columns_url")]
        public string columns_url { get; init; } = null!;

        [JsonPropertyName("id")]
        public int id { get; init; }

        [JsonPropertyName("node_id")]
        public string node_id { get; init; } = null!;

        [JsonPropertyName("name")]
        public string name { get; init; } = null!;

        [JsonPropertyName("body")]
        public string? body { get; init; }

        [JsonPropertyName("number")]
        public int number { get; init; }

        [JsonPropertyName("state")]
        public ProjectState State { get; init; }

        [JsonPropertyName("creator")]
        public User creator { get; init; } = null!;

        [JsonPropertyName("created_at")]
        public string created_at { get; init; } = null!;

        [JsonPropertyName("updated_at")]
        public string updated_at { get; init; } = null!;
    }
}
