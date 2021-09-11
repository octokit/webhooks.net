namespace JamieMagee.Octokit.Webhooks.Events.Organization
{
    public sealed class OrganizationAction : WebhookEventAction
    {
        public static readonly OrganizationAction Deleted = new(OrganizationActionValue.Deleted);

        public static readonly OrganizationAction MemberAdded = new(OrganizationActionValue.MemberAdded);

        public static readonly OrganizationAction MemberInvited = new(OrganizationActionValue.MemberInvited);

        public static readonly OrganizationAction MemberRemoved = new(OrganizationActionValue.MemberRemoved);

        public static readonly OrganizationAction Renamed = new(OrganizationActionValue.Renamed);

        private OrganizationAction(string value)
            : base(value)
        {
        }
    }
}
