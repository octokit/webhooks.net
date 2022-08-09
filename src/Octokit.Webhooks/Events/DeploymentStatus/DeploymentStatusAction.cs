namespace Octokit.Webhooks.Events.DeploymentStatus;

[PublicAPI]
public sealed record DeploymentStatusAction : WebhookEventAction
{
    public static readonly DeploymentStatusAction Created = new(DeploymentStatusActionValue.Created);

    private DeploymentStatusAction(string value)
        : base(value)
    {
    }
}
