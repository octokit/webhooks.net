namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record ContainerMetadataTag
{
    [JsonPropertyName("digest")]
    public string? Digest { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }
}
