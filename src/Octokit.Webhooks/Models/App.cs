namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record App
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("slug")]
    public string? Slug { get; init; }

    [JsonPropertyName("node_id")]
    public required string NodeId { get; init; }

    [JsonPropertyName("owner")]
    public required User Owner { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("external_url")]
    public required string ExternalUrl { get; init; }

    [JsonPropertyName("html_url")]
    public required string HtmlUrl { get; init; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset UpdatedAt { get; init; }

    [JsonPropertyName("permissions")]
    public AppPermissions? Permissions { get; init; }

    [JsonPropertyName("events")]
    [JsonConverter(typeof(StringEnumReadOnlyListConverter<AppEvent>))]
    public IReadOnlyList<StringEnum<AppEvent>>? Events { get; init; }
}
