namespace Octokit.Webhooks.Events.Sponsorship;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(SponsorshipActionValue.Created)]
public sealed record SponsorshipCreatedEvent : SponsorshipEvent
{
    [JsonPropertyName("action")]
    public override string Action => SponsorshipAction.Created;
}