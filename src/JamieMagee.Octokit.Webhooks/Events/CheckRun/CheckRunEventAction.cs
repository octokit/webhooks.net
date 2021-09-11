namespace JamieMagee.Octokit.Webhooks.Events.CheckRun
{
    public sealed class CheckRunEventAction : WebhookEventAction
    {
        public static readonly CheckRunEventAction Completed = new(CheckRunEventActionValue.Completed);

        public static readonly CheckRunEventAction Created = new(CheckRunEventActionValue.Created);

        public static readonly CheckRunEventAction RequestedAction = new(CheckRunEventActionValue.RequestedAction);

        public static readonly CheckRunEventAction Rerequested = new(CheckRunEventActionValue.Rerequested);

        private CheckRunEventAction(string value)
            : base(value)
        {
        }
    }
}
