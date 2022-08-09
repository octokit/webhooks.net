namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.Milestone)]
[JsonConverter(typeof(WebhookConverter<MilestoneEvent>))]
public abstract record MilestoneEvent : WebhookEvent
{
    [JsonPropertyName("milestone")]
    public Models.Milestone Milestone { get; init; } = null!;
}
