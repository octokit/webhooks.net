namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.Member)]
[JsonConverter(typeof(WebhookConverter<MemberEvent>))]
public abstract record MemberEvent : WebhookEvent
{
    [JsonPropertyName("member")]
    public required User Member { get; init; }
}
