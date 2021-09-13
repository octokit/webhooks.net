namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;
    using JamieMagee.Octokit.Webhooks.Models.CheckRunEvent;

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
