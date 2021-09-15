namespace JamieMagee.Octokit.Webhooks.Events.MarketplacePurchase
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(MarketplacePurchaseActionValue.Changed)]
    public sealed record MarketplacePurchaseChangedEvent : MarketplacePurchaseEvent
    {
        [JsonPropertyName("action")]
        public override string Action => MarketplacePurchaseAction.Changed;
    }
}
