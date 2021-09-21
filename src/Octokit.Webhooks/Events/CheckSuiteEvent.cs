namespace Octokit.Webhooks
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;
    using Octokit.Webhooks.Converter;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.CheckSuite)]
    [JsonConverter(typeof(WebhookConverter<CheckSuiteEvent>))]
    public abstract record CheckSuiteEvent : WebhookEvent
    {
    }
}
