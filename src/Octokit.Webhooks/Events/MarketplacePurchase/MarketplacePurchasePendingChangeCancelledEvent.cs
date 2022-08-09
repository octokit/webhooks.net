namespace Octokit.Webhooks.Events.MarketplacePurchase;

[PublicAPI]
[WebhookActionType(MarketplacePurchaseActionValue.PendingChangeCancelled)]
public sealed record MarketplacePurchasePendingChangeCancelledEvent : MarketplacePurchaseEvent
{
    [JsonPropertyName("action")]
    public override string Action => MarketplacePurchaseAction.PendingChangeCancelled;
}
