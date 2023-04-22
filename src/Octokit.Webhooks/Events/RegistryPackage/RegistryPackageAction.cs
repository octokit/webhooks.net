namespace Octokit.Webhooks.Events.RegistryPackage;

[PublicAPI]
public sealed record RegistryPackageAction : WebhookEventAction
{
    public static readonly RegistryPackageAction Published = new(RegistryPackageActionValue.Published);

    public static readonly RegistryPackageAction Updated = new(RegistryPackageActionValue.Updated);

    private RegistryPackageAction(string value)
        : base(value)
    {
    }
}
