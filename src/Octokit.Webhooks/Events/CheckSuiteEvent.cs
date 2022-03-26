namespace Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;
    using Octokit.Webhooks.Converter;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.CheckSuite)]
    [JsonConverter(typeof(WebhookConverter<CheckSuiteEvent>))]
    public abstract record CheckSuiteEvent : WebhookEvent
    {
        [JsonPropertyName("check_suite")]
        public Models.CheckSuiteEvent.CheckSuite CheckSuite { get; init; } = null!;
    }
}
