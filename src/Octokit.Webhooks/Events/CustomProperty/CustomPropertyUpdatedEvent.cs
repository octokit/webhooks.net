using Octokit.Webhooks.Models.CustomProperty;

namespace Octokit.Webhooks.Events.CustomProperty;

[PublicAPI]
[WebhookActionType(CustomPropertyActionValue.Updated)]
public sealed record CustomPropertyUpdatedEvent : CustomPropertyEvent
{
    [JsonPropertyName("action")]
    public override string Action => CustomPropertyAction.Updated;

    [JsonPropertyName("value_type")]
    [JsonConverter(typeof(StringEnumConverter<CustomPropertyValueType>))]
    public StringEnum<CustomPropertyValueType> ValueType { get; init; } = null!;

    [JsonPropertyName("default_value")]
    public string? DefaultValue { get; init; }

    [JsonPropertyName("required")]
    public bool Required { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("allowed_values")]
    public IEnumerable<string>? AllowedValues { get; init; }
}
