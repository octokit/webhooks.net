namespace Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using Octokit.Webhooks.Converter;
    using Octokit.Webhooks.Models.MetaEvent;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.Meta)]
    [JsonConverter(typeof(WebhookConverter<MetaEvent>))]
    public abstract record MetaEvent : WebhookEvent
    {
        [JsonPropertyName("hook_id")]
        public int HookId { get; init; }

        [JsonPropertyName("hook")]
        public Hook Hook { get; init; }
    }
}
