namespace Octokit.Webhooks.Models.ContentReferenceEvent;

[PublicAPI]
public sealed record ContentReference
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("node_id")]
    public required string NodeId { get; init; }

    [JsonPropertyName("reference")]
    public required string Reference { get; init; }
}
