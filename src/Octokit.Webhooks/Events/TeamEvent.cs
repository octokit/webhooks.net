namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.Team)]
[JsonConverter(typeof(WebhookConverter<TeamEvent>))]
public abstract record TeamEvent : WebhookEvent
{
    [JsonPropertyName("team")]
    public Models.Team Team { get; init; } = null!;
}
