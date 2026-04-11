namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.CustomPropertyPromotedToEnterprise)]
[JsonConverter(typeof(WebhookConverter<CustomPropertyPromotedToEnterpriseEvent>))]
public abstract record CustomPropertyPromotedToEnterpriseEvent : WebhookEvent
{
    [JsonPropertyName("definition")]
    public Models.CustomPropertyEvent.CustomProperty Definition { get; init; } = null!;
}
