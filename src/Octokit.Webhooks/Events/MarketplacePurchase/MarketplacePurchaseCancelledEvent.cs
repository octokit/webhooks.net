namespace Octokit.Webhooks.Events.MarketplacePurchase;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(MarketplacePurchaseActionValue.Cancelled)]
public sealed record MarketplacePurchaseCancelledEvent : MarketplacePurchaseEvent
{
    [JsonPropertyName("action")]
    public override string Action => MarketplacePurchaseAction.Cancelled;
}