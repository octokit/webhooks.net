namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record Label
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("node_id")]
    public required string NodeId { get; init; }

    [JsonPropertyName("url")]
    public required string Url { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("color")]
    public required string Color { get; init; }

    [JsonPropertyName("default")]
    public bool Default { get; init; }
}
