namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record ProjectsV2Item
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("node_id")]
    public required string NodeId { get; init; }

    [JsonPropertyName("project_node_id")]
    public required string ProjectNodeId { get; init; }

    [JsonPropertyName("content_node_id")]
    public required string ContentNodeId { get; init; }

    [JsonPropertyName("content_type")]
    [JsonConverter(typeof(StringEnumConverter<ProjectsV2ItemContentType>))]
    public required StringEnum<ProjectsV2ItemContentType> ContentType { get; init; }

    [JsonPropertyName("creator")]
    public required User Creator { get; init; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset UpdatedAt { get; init; }

    [JsonPropertyName("archived_at")]
    [JsonConverter(typeof(NullableDateTimeOffsetConverter))]
    public DateTimeOffset? ArchivedAt { get; init; }
}
