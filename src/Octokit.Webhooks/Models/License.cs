namespace Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record License
    {
        [JsonPropertyName("key")]
        public string Key { get; init; } = null!;

        [JsonPropertyName("name")]
        public string Name { get; init; } = null!;

        [JsonPropertyName("spdx_id")]
        public string SpdxId { get; init; } = null!;

        [JsonPropertyName("url")]
        public string? Url { get; init; }

        [JsonPropertyName("node_id")]
        public string NodeId { get; init; } = null!;
    }
}
