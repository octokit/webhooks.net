namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.Member)]
[JsonConverter(typeof(WebhookConverter<MemberEvent>))]
public abstract record MemberEvent : WebhookEvent
{
    [JsonPropertyName("member")]
    public User Member { get; init; } = null!;
}
