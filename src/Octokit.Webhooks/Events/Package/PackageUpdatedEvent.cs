namespace Octokit.Webhooks.Events.Package;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(PackageActionValue.Updated)]
public sealed record PackageUpdatedEvent : PackageEvent
{
    [JsonPropertyName("action")]
    public override string Action => PackageAction.Updated;
}