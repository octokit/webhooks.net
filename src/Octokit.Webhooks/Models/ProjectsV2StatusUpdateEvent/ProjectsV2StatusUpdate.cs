namespace Octokit.Webhooks.Models.ProjectsV2StatusUpdateEvent;

[PublicAPI]
public sealed record ProjectsV2StatusUpdate
{
    [JsonPropertyName("id")]
    public long Id { get; init; }

    [JsonPropertyName("node_id")]
    public string NodeId { get; init; } = null!;

    [JsonPropertyName("project_node_id")]
    public string ProjectNodeId { get; init; } = null!;

    [JsonPropertyName("creator")]
    public User Creator { get; init; } = null!;

    [JsonPropertyName("created_at")]
    public DateTimeOffset CreatedAt { get; init; }

    [JsonPropertyName("updated_at")]
    public DateTimeOffset UpdatedAt { get; init; }

    [JsonPropertyName("status")]
    public string? Status { get; init; }

    [JsonPropertyName("start_date")]
    public string? StartDate { get; init; }

    [JsonPropertyName("target_date")]
    public string? TargetDate { get; init; }

    [JsonPropertyName("body")]
    public string? Body { get; init; }
}
