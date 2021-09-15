namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.Delete)]
    public abstract record DeleteEvent : WebhookEvent
    {
        [JsonPropertyName("ref")]
        public string Ref { get; init; } = null!;

        [JsonPropertyName("ref_type")]
        public RefType RefType { get; init; }

        [JsonPropertyName("pusher_type")]
        public string PusherType { get; init; } = null!;
    }
}
