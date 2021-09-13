namespace JamieMagee.Octokit.Webhooks
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;

    [WebhookEventType(WebhookEventType.CheckSuite)]
    [JsonConverter(typeof(WebhookConverter<CheckSuiteEvent>))]
    public abstract record CheckSuiteEvent : WebhookEvent
    {
    }
}
