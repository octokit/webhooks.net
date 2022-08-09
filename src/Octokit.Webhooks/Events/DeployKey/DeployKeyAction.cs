namespace Octokit.Webhooks.Events.DeployKey;

[PublicAPI]
public sealed record DeployKeyAction : WebhookEventAction
{
    public static readonly DeployKeyAction Created = new(DeployKeyActionValue.Created);

    public static readonly DeployKeyAction Deleted = new(DeployKeyActionValue.Deleted);

    private DeployKeyAction(string value)
        : base(value)
    {
    }
}
