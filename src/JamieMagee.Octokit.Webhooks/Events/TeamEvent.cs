namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;

    [WebhookEventType(WebhookEventType.Team)]
    [JsonConverter(typeof(WebhookConverter<TeamEvent>))]
    public abstract record TeamEvent : WebhookEvent
    {
    }
}
