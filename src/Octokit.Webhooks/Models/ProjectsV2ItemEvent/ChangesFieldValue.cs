namespace Octokit.Webhooks.Models.ProjectsV2ItemEvent;

[PublicAPI]
public sealed record ChangesFieldValue
{
    [JsonPropertyName("field_type")]
    [JsonConverter(typeof(StringEnumConverter<FieldType>))]
    public StringEnum<FieldType> FieldType { get; init; } = null!;

    [JsonPropertyName("field_node_id")]
    public string FieldNodeId { get; init; } = null!;

    [JsonPropertyName("field_name")]
    public string FieldName { get; init; } = null!;

    [JsonPropertyName("project_number")]
    public long ProjectNumber { get; init; }

    [JsonPropertyName("from")]
    public ChangesFieldValueChangeBase From { get; init; } = null!;

    [JsonPropertyName("to")]
    public ChangesFieldValueChangeBase To { get; init; } = null!;
}
