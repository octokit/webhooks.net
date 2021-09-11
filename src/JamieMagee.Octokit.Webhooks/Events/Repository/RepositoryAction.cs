namespace JamieMagee.Octokit.Webhooks.Events.Repository
{
    public sealed class RepositoryAction : WebhookEventAction
    {
        public static readonly RepositoryAction Archived = new(RepositoryActionValue.Archived);

        public static readonly RepositoryAction Created = new(RepositoryActionValue.Created);

        public static readonly RepositoryAction Deleted = new(RepositoryActionValue.Deleted);

        public static readonly RepositoryAction Edited = new(RepositoryActionValue.Edited);

        public static readonly RepositoryAction Privatized = new(RepositoryActionValue.Privatized);

        public static readonly RepositoryAction Publicized = new(RepositoryActionValue.Publicized);

        public static readonly RepositoryAction Renamed = new(RepositoryActionValue.Renamed);

        public static readonly RepositoryAction Transferred = new(RepositoryActionValue.Transferred);

        public static readonly RepositoryAction Unarchived = new(RepositoryActionValue.Unarchived);

        private RepositoryAction(string value)
            : base(value)
        {
        }
    }
}
