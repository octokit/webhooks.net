namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.SecurityAndAnalysis)]
public sealed record SecurityAndAnalysisEvent : WebhookEvent
{
    [JsonPropertyName("changes")]
    public required Models.SecurityAndAnalysisEvent.Changes Changes { get; init; }
}
