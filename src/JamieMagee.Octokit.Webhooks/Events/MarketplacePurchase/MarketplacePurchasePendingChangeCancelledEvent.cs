namespace JamieMagee.Octokit.Webhooks.Events.MarketplacePurchase
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    [WebhookActionType(MarketplacePurchaseActionValue.PendingChangeCancelled)]
    public sealed record MarketplacePurchasePendingChangeCancelledEvent : MarketplacePurchaseEvent
    {
        [JsonPropertyName("action")]
        public override string Action => MarketplacePurchaseAction.PendingChangeCancelled;
    }
}
