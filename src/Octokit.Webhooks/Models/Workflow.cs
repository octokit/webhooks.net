namespace Octokit.Webhooks.Models;

[PublicAPI]
public sealed record Workflow
{
    [JsonPropertyName("badge_url")]
    public required string BadgeUrl { get; init; }

    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("html_url")]
    public required string HtmlUrl { get; init; }

    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("node_id")]
    public required string NodeId { get; init; }

    [JsonPropertyName("path")]
    public required string Path { get; init; }

    [JsonPropertyName("state")]
    [JsonConverter(typeof(StringEnumConverter<WorkflowState>))]
    public required StringEnum<WorkflowState> State { get; init; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset UpdatedAt { get; init; }

    [JsonPropertyName("url")]
    public required string Url { get; init; }
}
