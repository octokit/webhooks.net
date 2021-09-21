namespace Octokit.Webhooks.Events.Membership
{
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record MembershipAction : WebhookEventAction
    {
        public static readonly MembershipAction Added = new(MembershipActionValue.Added);

        public static readonly MembershipAction Removed = new(MembershipActionValue.Removed);

        private MembershipAction(string value)
            : base(value)
        {
        }
    }
}
