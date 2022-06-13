namespace Octokit.Webhooks.Events;

using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Models.PingEvent;

[PublicAPI]
[WebhookEventType(WebhookEventType.Ping)]
public sealed record PingEvent : WebhookEvent
{
    [JsonPropertyName("zen")]
    public string Zen { get; init; } = null!;

    [JsonPropertyName("hook_id")]
    public long HookId { get; init; }

    [JsonPropertyName("hook")]
    public Hook Hook { get; init; } = null!;
}