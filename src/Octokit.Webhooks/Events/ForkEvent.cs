namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.Fork)]
public sealed record ForkEvent : WebhookEvent
{
    [JsonPropertyName("forkee")]
    public Models.Repository Forkee { get; init; } = null!;
}
