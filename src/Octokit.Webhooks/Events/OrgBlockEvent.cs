namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.OrgBlock)]
[JsonConverter(typeof(WebhookConverter<OrgBlockEvent>))]
public abstract record OrgBlockEvent : WebhookEvent
{
    [JsonPropertyName("blocked_user")]
    public User BlockedUser { get; init; } = null!;
}
