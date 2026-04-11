namespace Octokit.Webhooks.Models.ProjectsV2ItemEvent;

[PublicAPI]
public sealed record ChangesFieldValue
{
    [JsonPropertyName("field_type")]
    [JsonConverter(typeof(StringEnumConverter<FieldType>))]
    public required StringEnum<FieldType> FieldType { get; init; }

    [JsonPropertyName("field_node_id")]
    public required string FieldNodeId { get; init; }

    [JsonPropertyName("field_name")]
    public required string FieldName { get; init; }

    [JsonPropertyName("project_number")]
    public long ProjectNumber { get; init; }

    [JsonPropertyName("from")]
    public required ChangesFieldValueChangeBase From { get; init; }

    [JsonPropertyName("to")]
    public required ChangesFieldValueChangeBase To { get; init; }
}
