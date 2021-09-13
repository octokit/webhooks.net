namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;

    [WebhookEventType(WebhookEventType.Issues)]
    [JsonConverter(typeof(WebhookConverter<IssuesEvent>))]
    public abstract record IssuesEvent : WebhookEvent
    {
    }
}
