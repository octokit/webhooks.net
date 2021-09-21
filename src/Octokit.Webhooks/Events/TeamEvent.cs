namespace Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using Octokit.Webhooks.Converter;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.Team)]
    [JsonConverter(typeof(WebhookConverter<TeamEvent>))]
    public abstract record TeamEvent : WebhookEvent
    {
        [JsonPropertyName("team")]
        public Models.Team Team { get; init; } = null!;
    }
}
