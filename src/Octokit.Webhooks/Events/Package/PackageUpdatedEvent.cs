namespace Octokit.Webhooks.Events.Package;

[PublicAPI]
[WebhookActionType(PackageActionValue.Updated)]
public sealed record PackageUpdatedEvent : PackageEvent
{
    [JsonPropertyName("action")]
    public override string Action => PackageAction.Updated;
}
