namespace JamieMagee.Octokit.Webhooks.Events.SecurityAdvisory
{
    public sealed class SecurityAdvisoryAction : WebhookEventAction
    {
        public static readonly SecurityAdvisoryAction Performed = new(SecurityAdvisoryActionValue.Performed);

        public static readonly SecurityAdvisoryAction Published = new(SecurityAdvisoryActionValue.Published);

        public static readonly SecurityAdvisoryAction Updated = new(SecurityAdvisoryActionValue.Updated);

        public static readonly SecurityAdvisoryAction Withdrawn = new(SecurityAdvisoryActionValue.Withdrawn);

        private SecurityAdvisoryAction(string value)
            : base(value)
        {
        }
    }
}
