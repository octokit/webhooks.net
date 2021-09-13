namespace JamieMagee.Octokit.Webhooks.Events.MarketplacePurchase
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    [WebhookActionType(MarketplacePurchaseActionValue.PendingChange)]
    public sealed record MarketplacePurchasePendingChangeEvent : MarketplacePurchaseEvent
    {
        [JsonPropertyName("action")]
        public override string Action => MarketplacePurchaseAction.PendingChange;
    }
}
