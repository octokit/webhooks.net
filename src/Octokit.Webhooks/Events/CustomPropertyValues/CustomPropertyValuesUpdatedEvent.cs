namespace Octokit.Webhooks.Events.CustomPropertyValues;

[PublicAPI]
[WebhookActionType(CustomPropertyValuesActionValue.Updated)]
public sealed record CustomPropertyValuesUpdatedEvent : CustomPropertyValuesEvent
{
    [JsonPropertyName("action")]
    public override string Action => CustomPropertyValuesAction.Updated;

    [JsonPropertyName("new_property_values")]
    public required IReadOnlyList<Models.CustomPropertyValuesEvent.CustomPropertyValue> NewPropertyValues { get; init; }

    [JsonPropertyName("old_property_values")]
    public required IReadOnlyList<Models.CustomPropertyValuesEvent.CustomPropertyValue> OldPropertyValues { get; init; }
}
