namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record ProjectCard
{
    [JsonPropertyName("url")]
    public required string Url { get; init; }

    [JsonPropertyName("project_url")]
    public required string ProjectUrl { get; init; }

    [JsonPropertyName("column_url")]
    public required string ColumnUrl { get; init; }

    [JsonPropertyName("column_id")]
    public long ColumnId { get; init; }

    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("node_id")]
    public required string NodeId { get; init; }

    [JsonPropertyName("note")]
    public string? Note { get; init; }

    [JsonPropertyName("archived")]
    public bool Archived { get; init; }

    [JsonPropertyName("creator")]
    public required User Creator { get; init; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset UpdatedAt { get; init; }

    [JsonPropertyName("content_url")]
    public string? ContentUrl { get; init; }

    [JsonPropertyName("after_id")]
    public long? AfterId { get; init; }
}
