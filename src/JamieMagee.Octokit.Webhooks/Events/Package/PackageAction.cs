namespace JamieMagee.Octokit.Webhooks.Events.Package
{
    public sealed class PackageAction : WebhookEventAction
    {
        public static readonly PackageAction Published = new(PackageActionValue.Published);

        public static readonly PackageAction Updated = new(PackageActionValue.Updated);

        private PackageAction(string value)
            : base(value)
        {
        }
    }
}
