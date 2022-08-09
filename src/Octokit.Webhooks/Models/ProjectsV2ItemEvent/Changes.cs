namespace Octokit.Webhooks.Models.ProjectsV2ItemEvent;

[PublicAPI]
public sealed record Changes
{
    [JsonPropertyName("archived_at")]
    public ChangesArchivedAt? ArchivedAt { get; init; }

    [JsonPropertyName("content_type")]
    public ChangesContentType? ContentType { get; init; }

    [JsonPropertyName("field_value")]
    public ChangesFieldValue? FieldValue { get; init; }

    [JsonPropertyName("previous_projects_v2_item_node_id")]
    public ChangesPreviousProjectsV2ItemNodeId? PreviousProjectsV2ItemNodeId { get; init; }
}
