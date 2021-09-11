namespace JamieMagee.Octokit.Webhooks.Events.Milestone
{
    public sealed class MilestoneAction : WebhookEventAction
    {
        public static readonly MilestoneAction Closed = new(MilestoneActionValue.Closed);

        public static readonly MilestoneAction Created = new(MilestoneActionValue.Created);

        public static readonly MilestoneAction Deleted = new(MilestoneActionValue.Deleted);

        public static readonly MilestoneAction Edited = new(MilestoneActionValue.Edited);

        public static readonly MilestoneAction Opened = new(MilestoneActionValue.Opened);

        private MilestoneAction(string value)
            : base(value)
        {
        }
    }
}
