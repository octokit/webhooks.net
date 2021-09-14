namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;
    using JamieMagee.Octokit.Webhooks.Models;

    [WebhookEventType(WebhookEventType.Issues)]
    [JsonConverter(typeof(WebhookConverter<IssuesEvent>))]
    public abstract record IssuesEvent : WebhookEvent
    {
        [JsonPropertyName("issue")]
        public Issue Issue { get; init; }
    }
}
