namespace Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using Octokit.Webhooks.Converter;
    using Octokit.Webhooks.Models;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.Member)]
    [JsonConverter(typeof(WebhookConverter<MemberEvent>))]
    public abstract record MemberEvent : WebhookEvent
    {
        [JsonPropertyName("member")]
        public User Member { get; init; } = null!;
    }
}
