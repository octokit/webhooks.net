namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;

    [WebhookEventType(WebhookEventType.Project)]
    [JsonConverter(typeof(WebhookConverter<ProjectEvent>))]
    public abstract record ProjectEvent : WebhookEvent
    {
    }
}
