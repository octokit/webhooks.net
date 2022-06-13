namespace Octokit.Webhooks.Events.Sponsorship;

using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Models.SponsorshipEvent;

[PublicAPI]
[WebhookActionType(SponsorshipActionValue.Edited)]
public sealed record SponsorshipEditedEvent : SponsorshipEvent
{
    [JsonPropertyName("action")]
    public override string Action => SponsorshipAction.Edited;

    [JsonPropertyName("changes")]
    public Changes Changes { get; init; } = null!;
}
