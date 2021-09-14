namespace JamieMagee.Octokit.Webhooks.Models.ContentReferenceEvent
{
    using System.Text.Json.Serialization;

    public sealed record ContentReference
    {
        [JsonPropertyName("id")]
        public int Id { get; init; }

        [JsonPropertyName("node_id")]
        public string NodeId { get; init; } = null!;

        [JsonPropertyName("reference")]
        public string Reference { get; init; } = null!;
    }
}
