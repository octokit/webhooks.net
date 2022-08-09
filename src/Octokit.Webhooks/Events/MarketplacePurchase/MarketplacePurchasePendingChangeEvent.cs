namespace Octokit.Webhooks.Events.MarketplacePurchase;

[PublicAPI]
[WebhookActionType(MarketplacePurchaseActionValue.PendingChange)]
public sealed record MarketplacePurchasePendingChangeEvent : MarketplacePurchaseEvent
{
    [JsonPropertyName("action")]
    public override string Action => MarketplacePurchaseAction.PendingChange;
}
