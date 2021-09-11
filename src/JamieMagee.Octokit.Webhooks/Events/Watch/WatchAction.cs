namespace JamieMagee.Octokit.Webhooks.Events.Watch
{
    public sealed class WatchAction : WebhookEventAction
    {
        public static readonly WatchAction Started = new(WatchActionValue.Started);

        private WatchAction(string value)
            : base(value)
        {
        }
    }
}
