namespace Octokit.Webhooks.Models.ProjectsV2ItemEvent;

[PublicAPI]
public sealed record ChangesFieldValue
{
    [JsonPropertyName("field_type")]
    [JsonConverter(typeof(StringEnumConverter<FieldType>))]
    public StringEnum<FieldType> FieldType { get; init; } = null!;

    [JsonPropertyName("field_node_id")]
    public string FieldNodeId { get; init; } = null!;
}
