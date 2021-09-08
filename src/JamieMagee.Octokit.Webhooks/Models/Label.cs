namespace JamieMagee.Octokit.Webhooks.Models
{
    using System.Text.Json.Serialization;

    public class Label
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("node_id")]
        public string NodeId { get; set; } = null!;

        [JsonPropertyName("url")]
        public string Url { get; set; } = null!;

        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("color")]
        public string Color { get; set; } = null!;

        [JsonPropertyName("default")]
        public bool Default { get; set; }
    }
}
