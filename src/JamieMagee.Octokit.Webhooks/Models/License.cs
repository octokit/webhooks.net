namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;

    public sealed record License
    {
        [JsonPropertyName("key")]
        public string Key { get; set; } = null!;

        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("spdx_id")]
        public string SpdxId { get; set; } = null!;

        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonPropertyName("node_id")]
        public string NodeId { get; set; } = null!;
    }
}
