namespace Octokit.Webhooks.Events.Sponsorship;

using JetBrains.Annotations;

[PublicAPI]
public sealed record SponsorshipAction : WebhookEventAction
{
    public static readonly SponsorshipAction Cancelled = new(SponsorshipActionValue.Cancelled);

    public static readonly SponsorshipAction Created = new(SponsorshipActionValue.Created);

    public static readonly SponsorshipAction Edited = new(SponsorshipActionValue.Edited);

    public static readonly SponsorshipAction PendingCancellation = new(SponsorshipActionValue.PendingCancellation);

    public static readonly SponsorshipAction PendingTierChange = new(SponsorshipActionValue.PendingTierChange);

    public static readonly SponsorshipAction TierChanged = new(SponsorshipActionValue.TierChanged);

    private SponsorshipAction(string value)
        : base(value)
    {
    }
}
