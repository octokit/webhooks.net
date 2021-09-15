namespace JamieMagee.Octokit.Webhooks.Events.Installation
{
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record InstallationAction : WebhookEventAction
    {
        public static readonly InstallationAction Created = new(InstallationActionValue.Created);

        public static readonly InstallationAction Deleted = new(InstallationActionValue.Deleted);

        public static readonly InstallationAction NewPermissionsAccepted = new(InstallationActionValue.NewPermissionsAccepted);

        public static readonly InstallationAction Suspend = new(InstallationActionValue.Suspend);

        public static readonly InstallationAction Unsuspend = new(InstallationActionValue.Unsuspend);

        private InstallationAction(string value)
            : base(value)
        {
        }
    }
}
