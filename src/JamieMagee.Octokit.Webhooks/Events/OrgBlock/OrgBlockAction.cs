namespace JamieMagee.Octokit.Webhooks.Events.OrgBlock
{
    public sealed class OrgBlockAction : WebhookEventAction
    {
        public static readonly OrgBlockAction Blocked = new(OrgBlockActionValue.Blocked);

        public static readonly OrgBlockAction Unblocked = new(OrgBlockActionValue.Unblocked);

        private OrgBlockAction(string value)
            : base(value)
        {
        }
    }
}
