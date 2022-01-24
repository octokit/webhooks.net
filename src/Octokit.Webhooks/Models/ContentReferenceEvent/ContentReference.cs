namespace Octokit.Webhooks.Models.ContentReferenceEvent
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record ContentReference
    {
        [JsonPropertyName("id")]
        public long Id { get; init; }

        [JsonPropertyName("node_id")]
        public string NodeId { get; init; } = null!;

        [JsonPropertyName("reference")]
        public string Reference { get; init; } = null!;
    }
}
