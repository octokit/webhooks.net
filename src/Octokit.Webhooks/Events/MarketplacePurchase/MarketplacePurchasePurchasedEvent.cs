namespace Octokit.Webhooks.Events.MarketplacePurchase;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(MarketplacePurchaseActionValue.Purchased)]
public sealed record MarketplacePurchasePurchasedEvent : MarketplacePurchaseEvent
{
    [JsonPropertyName("action")]
    public override string Action => MarketplacePurchaseAction.Purchased;
}
