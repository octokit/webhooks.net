namespace Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;
    using Octokit.Webhooks.Converter;
    using Octokit.Webhooks.Models;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.Member)]
    [JsonConverter(typeof(WebhookConverter<MemberEvent>))]
    public abstract record MemberEvent : WebhookEvent
    {
        [JsonPropertyName("member")]
        public User Member { get; init; } = null!;
    }
}
