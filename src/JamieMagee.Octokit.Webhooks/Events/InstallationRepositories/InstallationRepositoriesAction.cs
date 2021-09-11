namespace JamieMagee.Octokit.Webhooks.Events.InstallationRepositories
{
    public sealed class InstallationRepositoriesAction : WebhookEventAction
    {
        public static readonly InstallationRepositoriesAction Added = new(InstallationRepositoriesActionValue.Added);

        public static readonly InstallationRepositoriesAction Removed = new(InstallationRepositoriesActionValue.Removed);

        private InstallationRepositoriesAction(string value)
            : base(value)
        {
        }
    }
}
