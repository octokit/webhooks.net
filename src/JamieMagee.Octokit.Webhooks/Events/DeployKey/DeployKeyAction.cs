namespace JamieMagee.Octokit.Webhooks.Events.DeployKey
{
    public sealed class DeployKeyAction : WebhookEventAction
    {
        public static readonly DeployKeyAction Created = new(DeployKeyActionValue.Created);

        public static readonly DeployKeyAction Deleted = new(DeployKeyActionValue.Deleted);

        private DeployKeyAction(string value)
            : base(value)
        {
        }
    }
}
