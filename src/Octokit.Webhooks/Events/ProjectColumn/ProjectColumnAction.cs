namespace Octokit.Webhooks.Events.ProjectColumn
{
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record ProjectColumnAction : WebhookEventAction
    {
        public static readonly ProjectColumnAction Created = new(ProjectColumnActionValue.Created);

        public static readonly ProjectColumnAction Deleted = new(ProjectColumnActionValue.Deleted);

        public static readonly ProjectColumnAction Edited = new(ProjectColumnActionValue.Edited);

        public static readonly ProjectColumnAction Moved = new(ProjectColumnActionValue.Moved);

        private ProjectColumnAction(string value)
            : base(value)
        {
        }
    }
}
