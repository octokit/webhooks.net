namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.MarketplacePurchase)]
[JsonConverter(typeof(WebhookConverter<MarketplacePurchaseEvent>))]
public abstract record MarketplacePurchaseEvent : WebhookEvent
{
    [JsonPropertyName("effective_date")]
    public required string EffectiveDate { get; init; }

    [JsonPropertyName("marketplace_purchase")]
    public required Models.MarketplacePurchase MarketplacePurchase { get; init; }

    [JsonPropertyName("previous_marketplace_purchase")]
    public Models.MarketplacePurchase? PreviousMarketplacePurchase { get; init; }
}
