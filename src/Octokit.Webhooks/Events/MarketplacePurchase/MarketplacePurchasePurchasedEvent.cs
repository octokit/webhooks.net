namespace Octokit.Webhooks.Events.MarketplacePurchase;

[PublicAPI]
[WebhookActionType(MarketplacePurchaseActionValue.Purchased)]
public sealed record MarketplacePurchasePurchasedEvent : MarketplacePurchaseEvent
{
    [JsonPropertyName("action")]
    public override string Action => MarketplacePurchaseAction.Purchased;
}
