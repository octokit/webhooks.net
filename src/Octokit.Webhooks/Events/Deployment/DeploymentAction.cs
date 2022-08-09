namespace Octokit.Webhooks.Events.Deployment;

[PublicAPI]
public sealed record DeploymentAction : WebhookEventAction
{
    public static readonly DeploymentAction Created = new(DeploymentActionValue.Created);

    private DeploymentAction(string value)
        : base(value)
    {
    }
}
