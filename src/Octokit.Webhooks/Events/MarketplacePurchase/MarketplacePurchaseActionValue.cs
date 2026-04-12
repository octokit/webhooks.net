namespace Octokit.Webhooks.Events.MarketplacePurchase;

[PublicAPI]
public static class MarketplacePurchaseActionValue
{
    public const string Cancelled = "cancelled";

    public const string Changed = "changed";

    public const string PendingChange = "pending_change";

    public const string PendingChangeCancelled = "pending_change_cancelled";

    public const string Purchased = "purchased";
}
