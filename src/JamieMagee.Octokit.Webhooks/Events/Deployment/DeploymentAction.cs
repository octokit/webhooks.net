namespace JamieMagee.Octokit.Webhooks.Events.Deployment
{
    public sealed class DeploymentAction : WebhookEventAction
    {
        public static readonly DeploymentAction Created = new(DeploymentActionValue.Created);

        private DeploymentAction(string value)
            : base(value)
        {
        }
    }
}
