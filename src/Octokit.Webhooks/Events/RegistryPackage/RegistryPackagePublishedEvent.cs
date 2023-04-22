namespace Octokit.Webhooks.Events.RegistryPackage;

[PublicAPI]
[WebhookActionType(RegistryPackageActionValue.Published)]
public sealed record RegistryPackagePublishedEvent : RegistryPackageEvent
{
    [JsonPropertyName("action")]
    public override string Action => RegistryPackageAction.Published;
}
