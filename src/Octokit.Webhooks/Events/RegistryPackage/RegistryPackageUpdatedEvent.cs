namespace Octokit.Webhooks.Events.RegistryPackage;

[PublicAPI]
[WebhookActionType(RegistryPackageActionValue.Updated)]
public sealed record RegistryPackageUpdatedEvent : RegistryPackageEvent
{
    [JsonPropertyName("action")]
    public override string Action => RegistryPackageAction.Updated;
}
