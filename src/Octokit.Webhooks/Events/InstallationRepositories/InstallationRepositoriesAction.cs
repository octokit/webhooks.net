namespace Octokit.Webhooks.Events.InstallationRepositories;

[PublicAPI]
public sealed record InstallationRepositoriesAction : WebhookEventAction
{
    public static readonly InstallationRepositoriesAction Added = new(InstallationRepositoriesActionValue.Added);

    public static readonly InstallationRepositoriesAction Removed = new(InstallationRepositoriesActionValue.Removed);

    private InstallationRepositoriesAction(string value)
        : base(value)
    {
    }
}
