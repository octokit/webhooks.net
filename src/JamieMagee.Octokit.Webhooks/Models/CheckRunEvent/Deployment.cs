namespace JamieMagee.Octokit.Webhooks.Models.CheckRunEvent
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record CheckRunDeployment
    {
        [JsonPropertyName("url")]
        public string Url { get; init; } = null!;

        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("node_id")]
        public string NodeId { get; init; } = null!;

        [JsonPropertyName("task")]
        public string Task { get; init; } = null!;

        [JsonPropertyName("original_environment")]
        public string OriginalEnvironment { get; init; } = null!;

        [JsonPropertyName("environment")]
        public string Environment { get; init; } = null!;

        [JsonPropertyName("description")]
        public string? Description { get; init; }

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; init; } = null!;

        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; init; } = null!;

        [JsonPropertyName("statuses_url")]
        public string StatusesUrl { get; init; } = null!;

        [JsonPropertyName("repository_url")]
        public string RepositoryUrl { get; init; } = null!;
    }
}
