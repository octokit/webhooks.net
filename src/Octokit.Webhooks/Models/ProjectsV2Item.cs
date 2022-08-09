namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record ProjectsV2Item
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("node_id")]
    public string NodeId { get; init; } = null!;

    [JsonPropertyName("project_node_id")]
    public string ProjectNodeId { get; init; } = null!;

    [JsonPropertyName("content_node_id")]
    public string ContentNodeId { get; init; } = null!;

    [JsonPropertyName("content_type")]
    public ProjectsV2ItemContentType ContentType { get; init; }

    [JsonPropertyName("creator")]
    public User Creator { get; init; } = null!;

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
