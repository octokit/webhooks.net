namespace Octokit.Webhooks.Events;

using Octokit.Webhooks.Models.PingEvent;

[PublicAPI]
[WebhookEventType(WebhookEventType.Ping)]
public sealed record PingEvent : WebhookEvent
{
    [JsonPropertyName("zen")]
    public required string Zen { get; init; }

    [JsonPropertyName("hook_id")]
    public long HookId { get; init; }

    [JsonPropertyName("hook")]
    public required Hook Hook { get; init; }
}
