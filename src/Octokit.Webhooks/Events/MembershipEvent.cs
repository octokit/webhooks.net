namespace Octokit.Webhooks.Events;

using Octokit.Webhooks.Models.MembershipAddedEvent;

[PublicAPI]
[WebhookEventType(WebhookEventType.Membership)]
[JsonConverter(typeof(WebhookConverter<MembershipEvent>))]
public abstract record MembershipEvent : WebhookEvent
{
    [JsonPropertyName("scope")]
    [JsonConverter(typeof(StringEnumConverter<Scope>))]
    public required StringEnum<Scope> Scope { get; init; }

    [JsonPropertyName("member")]
    public required User Member { get; init; }

    [JsonPropertyName("team")]
    public required Models.Team Team { get; init; }
}
