namespace JamieMagee.Octokit.Webhooks.Events.Membership
{
    public sealed class MembershipAction : WebhookEventAction
    {
        public static readonly MembershipAction Added = new(MembershipActionValue.Added);

        public static readonly MembershipAction Removed = new(MembershipActionValue.Removed);

        private MembershipAction(string value)
            : base(value)
        {
        }
    }
}
