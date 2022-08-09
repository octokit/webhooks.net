namespace Octokit.Webhooks.Events.Package;

[PublicAPI]
[WebhookActionType(PackageActionValue.Published)]
public sealed record PackagePublishedEvent : PackageEvent
{
    [JsonPropertyName("action")]
    public override string Action => PackageAction.Published;
}
