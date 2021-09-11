namespace JamieMagee.Octokit.Webhooks.Events.DeploymentStatus
{
    public sealed class DeploymentStatusAction : WebhookEventAction
    {
        public static readonly DeploymentStatusAction Created = new(DeploymentStatusActionValue.Created);

        private DeploymentStatusAction(string value)
            : base(value)
        {
        }
    }
}
