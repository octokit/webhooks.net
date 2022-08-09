namespace Octokit.Webhooks.Events;

using Octokit.Webhooks.Models.MembershipAddedEvent;

[PublicAPI]
[WebhookEventType(WebhookEventType.Membership)]
[JsonConverter(typeof(WebhookConverter<MembershipEvent>))]
public abstract record MembershipEvent : WebhookEvent
{
    [JsonPropertyName("scope")]
    public Scope Scope { get; init; }

    [JsonPropertyName("member")]
    public User Member { get; init; } = null!;

    [JsonPropertyName("team")]
    public Models.Team Team { get; init; } = null!;
}
