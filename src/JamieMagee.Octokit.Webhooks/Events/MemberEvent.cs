namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;

    [WebhookEventType(WebhookEventType.Member)]
    [JsonConverter(typeof(WebhookConverter<MemberEvent>))]
    public abstract record MemberEvent : WebhookEvent
    {
    }
}
