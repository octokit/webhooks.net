namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.Milestone)]
[JsonConverter(typeof(WebhookConverter<MilestoneEvent>))]
public abstract record MilestoneEvent : WebhookEvent
{
    [JsonPropertyName("milestone")]
    public required Models.Milestone Milestone { get; init; }
}
