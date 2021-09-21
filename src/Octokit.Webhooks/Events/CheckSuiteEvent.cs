namespace Octokit.Webhooks
{
    using System.Text.Json.Serialization;
    using Octokit.Webhooks.Converter;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.CheckSuite)]
    [JsonConverter(typeof(WebhookConverter<CheckSuiteEvent>))]
    public abstract record CheckSuiteEvent : WebhookEvent
    {
    }
}
