namespace Octokit.Webhooks.Events.MarketplacePurchase;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(MarketplacePurchaseActionValue.PendingChange)]
public sealed record MarketplacePurchasePendingChangeEvent : MarketplacePurchaseEvent
{
    [JsonPropertyName("action")]
    public override string Action => MarketplacePurchaseAction.PendingChange;
}