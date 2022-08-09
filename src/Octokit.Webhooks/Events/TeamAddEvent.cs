namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.TeamAdd)]
public sealed record TeamAddEvent : WebhookEvent
{
    [JsonPropertyName("team")]
    public Models.Team Team { get; init; } = null!;
}
