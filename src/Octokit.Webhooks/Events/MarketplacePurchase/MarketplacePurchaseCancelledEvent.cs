namespace Octokit.Webhooks.Events.MarketplacePurchase;

[PublicAPI]
[WebhookActionType(MarketplacePurchaseActionValue.Cancelled)]
public sealed record MarketplacePurchaseCancelledEvent : MarketplacePurchaseEvent
{
    [JsonPropertyName("action")]
    public override string Action => MarketplacePurchaseAction.Cancelled;
}
