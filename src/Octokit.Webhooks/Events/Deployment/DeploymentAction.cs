namespace Octokit.Webhooks.Events.Deployment;

using JetBrains.Annotations;

[PublicAPI]
public sealed record DeploymentAction : WebhookEventAction
{
    public static readonly DeploymentAction Created = new(DeploymentActionValue.Created);

    private DeploymentAction(string value)
        : base(value)
    {
    }
}