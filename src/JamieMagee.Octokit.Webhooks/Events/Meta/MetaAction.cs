namespace JamieMagee.Octokit.Webhooks.Events.Meta
{
    public sealed class MetaAction : WebhookEventAction
    {
        public static readonly MetaAction Deleted = new(MetaActionValue.Deleted);

        private MetaAction(string value)
            : base(value)
        {
        }
    }
}
