namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record InstallationLite
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("node_id")]
    public string NodeId { get; init; } = null!;
}
