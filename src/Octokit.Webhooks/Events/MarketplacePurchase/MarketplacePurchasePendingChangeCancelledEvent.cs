namespace Octokit.Webhooks.Events.MarketplacePurchase;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(MarketplacePurchaseActionValue.PendingChangeCancelled)]
public sealed record MarketplacePurchasePendingChangeCancelledEvent : MarketplacePurchaseEvent
{
    [JsonPropertyName("action")]
    public override string Action => MarketplacePurchaseAction.PendingChangeCancelled;
}