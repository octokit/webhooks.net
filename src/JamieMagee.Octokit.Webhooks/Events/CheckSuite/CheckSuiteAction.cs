namespace JamieMagee.Octokit.Webhooks.Events.CheckSuite
{
    public sealed class CheckSuiteAction : WebhookEventAction
    {
        public static readonly CheckSuiteAction Completed = new(CheckSuiteActionValue.Completed);

        public static readonly CheckSuiteAction Requested = new(CheckSuiteActionValue.Requested);

        public static readonly CheckSuiteAction Rerequested = new(CheckSuiteActionValue.Rerequested);

        private CheckSuiteAction(string value)
            : base(value)
        {
        }
    }
}
