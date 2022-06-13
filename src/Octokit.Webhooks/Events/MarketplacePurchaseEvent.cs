namespace Octokit.Webhooks.Events;

using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Converter;

[PublicAPI]
[WebhookEventType(WebhookEventType.MarketplacePurchase)]
[JsonConverter(typeof(WebhookConverter<MarketplacePurchaseEvent>))]
public abstract record MarketplacePurchaseEvent : WebhookEvent
{
    [JsonPropertyName("effective_date")]
    public string EffectiveDate { get; init; } = null!;

    [JsonPropertyName("marketplace_purchase")]
    public Models.MarketplacePurchase MarketplacePurchase { get; init; } = null!;

    [JsonPropertyName("previous_marketplace_purchase")]
    public Models.MarketplacePurchase? PreviousMarketplacePurchase { get; init; }
}
