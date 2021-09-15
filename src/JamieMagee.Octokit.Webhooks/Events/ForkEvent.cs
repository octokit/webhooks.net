namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.Fork)]
    public sealed record ForkEvent : WebhookEvent
    {
        [JsonPropertyName("forkee")]
        public Models.Repository Forkee { get; init; }
    }
}
