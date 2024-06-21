namespace Octokit.Webhooks.Models.CustomPropertyEvent;

using System.Linq;

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
    public object? Default { get; init; }

    public string? DefaultValue => this.Default switch
    {
        string str => str,
        IEnumerable<string> strings => "[" + string.Join(",", strings) + "]",
        JsonElement json when json.ValueKind is JsonValueKind.String => json.GetString(),
        JsonElement json when json.ValueKind is JsonValueKind.Array => "[" + string.Join(",", json.EnumerateArray().Select(e => e.GetString()!)) + "]",
        _ => null,
    };

    public IEnumerable<string>? DefaultValues => this.Default switch
    {
        string str => [str],
        IEnumerable<string> strings => strings,
        JsonElement json when json.ValueKind is JsonValueKind.String => [json.GetString()],
        JsonElement json when json.ValueKind is JsonValueKind.Array => json.EnumerateArray().Select(e => e.GetString()!),
        _ => null,
    };

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("allowed_values")]
    public IEnumerable<string>? AllowedValues { get; init; }

    [JsonPropertyName("values_editable_by")]
    [JsonConverter(typeof(StringEnumConverter<CustomPropertyValuesEditableBy>))]
    public StringEnum<CustomPropertyValuesEditableBy>? ValuesEditableBy { get; init; }
}
