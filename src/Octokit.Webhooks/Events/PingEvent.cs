namespace Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using Octokit.Webhooks.Models.PingEvent;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.Ping)]
    public sealed record PingEvent : WebhookEvent
    {
        [JsonPropertyName("zen")]
        public string Zen { get; init; }

        [JsonPropertyName("hook_id")]
        public int HookId { get; init; }

        [JsonPropertyName("hook")]
        public Hook Hook { get; init; }
    }
}
