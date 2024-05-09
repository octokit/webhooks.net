namespace Octokit.Webhooks.Models.CustomPropertyEvent;

[PublicAPI]
public sealed record CustomProperty
{
    [JsonPropertyName("property_name")]
    public string PropertyName { get; init; } = null!;

    [JsonPropertyName("value_type")]
    [JsonConverter(typeof(StringEnumConverter<CustomPropertyValueType>))]
    public StringEnum<CustomPropertyValueType> ValueType { get; init; } = null!;

    [JsonPropertyName("required")]
    public bool Required { get; init; }

    [JsonPropertyName("default_value")]
    public string? DefaultValue { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("allowed_values")]
    public IEnumerable<string>? AllowedValues { get; init; }

    [JsonPropertyName("editable_by")]
    [JsonConverter(typeof(StringEnumConverter<CustomPropertyValuesEditableBy>))]
    public StringEnum<CustomPropertyValuesEditableBy> EditableBy { get; init; } = null!;
}
