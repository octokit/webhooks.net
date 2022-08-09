namespace Octokit.Webhooks.Events.MarketplacePurchase;

[PublicAPI]
[WebhookActionType(MarketplacePurchaseActionValue.Changed)]
public sealed record MarketplacePurchaseChangedEvent : MarketplacePurchaseEvent
{
    [JsonPropertyName("action")]
    public override string Action => MarketplacePurchaseAction.Changed;
}
