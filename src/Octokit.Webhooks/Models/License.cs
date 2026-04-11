namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record License
{
    [JsonPropertyName("key")]
    public required string Key { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("spdx_id")]
    public required string SpdxId { get; init; }

    [JsonPropertyName("url")]
    public string? Url { get; init; }

    [JsonPropertyName("node_id")]
    public required string NodeId { get; init; }
}
