namespace Octokit.Webhooks.Events.Sponsorship;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(SponsorshipActionValue.Cancelled)]
public sealed record SponsorshipCancelledEvent : SponsorshipEvent
{
    [JsonPropertyName("action")]
    public override string Action => SponsorshipAction.Cancelled;
}
