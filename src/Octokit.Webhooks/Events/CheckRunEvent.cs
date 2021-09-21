namespace Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using Octokit.Webhooks.Converter;
    using Octokit.Webhooks.Models.CheckRunEvent;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.CheckRun)]
    [JsonConverter(typeof(WebhookConverter<CheckRunEvent>))]
    public abstract record CheckRunEvent : WebhookEvent
    {
        [JsonPropertyName("check_run")]
        public Models.CheckRunEvent.CheckRun CheckRun { get; init; } = null!;

        [JsonPropertyName("requested_action")]
        public RequestedAction? RequestedAction { get; init; }
    }
}
