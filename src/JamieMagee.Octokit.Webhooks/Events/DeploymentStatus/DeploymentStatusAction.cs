namespace JamieMagee.Octokit.Webhooks.Events.DeploymentStatus
{
    using JetBrains.Annotations;

    [PublicAPI]
    public sealed record DeploymentStatusAction : WebhookEventAction
    {
        public static readonly DeploymentStatusAction Created = new(DeploymentStatusActionValue.Created);

        private DeploymentStatusAction(string value)
            : base(value)
        {
        }
    }
}
