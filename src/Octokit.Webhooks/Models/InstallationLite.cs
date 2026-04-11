namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record InstallationLite
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("node_id")]
    public required string NodeId { get; init; }
}
