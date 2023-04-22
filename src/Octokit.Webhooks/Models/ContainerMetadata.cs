namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record ContainerMetadata
{
    [JsonPropertyName("labels")]
    public IDictionary<string, dynamic>? Labels { get; init; }

    [JsonPropertyName("labels")]
    public IDictionary<string, dynamic>? Manifest { get; init; }

    [JsonPropertyName("tag")]
    public ContainerMetadataTag? Tag { get; init; }
}
