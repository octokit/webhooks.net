namespace Octokit.Webhooks.Models.InstallationEvent;

[PublicAPI]
public sealed record Repository
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("node_id")]
    public required string NodeId { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("full_name")]
    public required string FullName { get; init; }

    [JsonPropertyName("private")]
    public bool Private { get; init; }
}
