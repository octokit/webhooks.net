namespace JamieMagee.Octokit.Webhooks.Models.CheckRunEvent
{
    using System.Text.Json.Serialization;

    public sealed record CheckRunDeployment
    {
        [JsonPropertyName("url")]
        public string Url { get; set; } = null!;

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("node_id")]
        public string NodeId { get; set; } = null!;

        [JsonPropertyName("task")]
        public string Task { get; set; } = null!;

        [JsonPropertyName("original_environment")]
        public string OriginalEnvironment { get; set; } = null!;

        [JsonPropertyName("environment")]
        public string Environment { get; set; } = null!;

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; set; } = null!;

        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; set; } = null!;

        [JsonPropertyName("statuses_url")]
        public string StatusesUrl { get; set; } = null!;

        [JsonPropertyName("repository_url")]
        public string RepositoryUrl { get; set; } = null!;
    }
}
