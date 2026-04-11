namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record ProjectColumn
{
    [JsonPropertyName("url")]
    public required string Url { get; init; }

    [JsonPropertyName("project_url")]
    public required string ProjectUrl { get; init; }

    [JsonPropertyName("cards_url")]
    public required string CardsUrl { get; init; }

    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("node_id")]
    public required string NodeId { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset UpdatedAt { get; init; }
}
