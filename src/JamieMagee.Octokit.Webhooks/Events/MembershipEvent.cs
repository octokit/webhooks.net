namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;

    [WebhookEventType(WebhookEventType.Membership)]
    [JsonConverter(typeof(WebhookConverter<MembershipEvent>))]
    public abstract record MembershipEvent : WebhookEvent
    {
    }
}
