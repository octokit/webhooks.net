namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;
    using JamieMagee.Octokit.Webhooks.Models;

    [WebhookEventType(WebhookEventType.Member)]
    [JsonConverter(typeof(WebhookConverter<MemberEvent>))]
    public abstract record MemberEvent : WebhookEvent
    {
        [JsonPropertyName("member")]
        public User Member { get; init; } = null!;
    }
}
