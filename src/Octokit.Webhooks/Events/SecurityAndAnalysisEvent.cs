namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.SecurityAndAnalysis)]
public sealed record SecurityAndAnalysisEvent : WebhookEvent
{
    [JsonPropertyName("changes")]
    public Models.SecurityAndAnalysisEvent.Changes Changes { get; init; } = null!;
}
