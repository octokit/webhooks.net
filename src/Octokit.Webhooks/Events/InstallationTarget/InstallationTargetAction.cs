namespace Octokit.Webhooks.Events.InstallationTarget;

[PublicAPI]
public sealed record InstallationTargetAction : WebhookEventAction
{
    public static readonly InstallationTargetAction Renamed = new(InstallationTargetActionValue.Renamed);

    private InstallationTargetAction(string value)
        : base(value)
    {
    }
}
