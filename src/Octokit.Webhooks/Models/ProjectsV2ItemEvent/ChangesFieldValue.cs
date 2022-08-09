namespace Octokit.Webhooks.Models.ProjectsV2ItemEvent;

[PublicAPI]
public sealed record ChangesFieldValue
{
    [JsonPropertyName("field_type")]
    public FieldType FieldType { get; init; }

    [JsonPropertyName("field_node_id")]
    public string FieldNodeId { get; init; } = null!;
}
