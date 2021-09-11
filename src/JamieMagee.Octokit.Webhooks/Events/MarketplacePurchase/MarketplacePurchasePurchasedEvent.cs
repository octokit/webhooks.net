namespace JamieMagee.Octokit.Webhooks.Events.MarketplacePurchase
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    public sealed record MarketplacePurchasePurchasedEvent : MarketplacePurchaseEvent
    {
        [JsonPropertyName("action")]
        public override string Action => MarketplacePurchaseAction.Purchased;
    }
}
