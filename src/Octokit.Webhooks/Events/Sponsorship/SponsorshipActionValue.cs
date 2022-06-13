namespace Octokit.Webhooks.Events.Sponsorship;

public static class SponsorshipActionValue
{
    public const string Cancelled = "cancelled";

    public const string Created = "created";

    public const string Edited = "edited";

    public const string PendingCancellation = "pending_cancellation";

    public const string PendingTierChange = "pending_tier_change";

    public const string TierChanged = "tier_changed";
}
