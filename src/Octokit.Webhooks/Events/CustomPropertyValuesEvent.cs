using Octokit.Webhooks.Models.CustomPropertyValues;

namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.CustomPropertyValues)]
[JsonConverter(typeof(WebhookConverter<CustomPropertyValuesEvent>))]
public abstract record CustomPropertyValuesEvent : WebhookEvent
{
    [JsonPropertyName("new_property_values")]
    public IEnumerable<CustomPropertyValue> NewPropertyValues { get; init; } = null!;

    [JsonPropertyName("old_property_values")]
    public IEnumerable<CustomPropertyValue> OldPropertyValues { get; init; } = null!;
}
