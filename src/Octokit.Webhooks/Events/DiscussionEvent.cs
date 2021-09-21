namespace Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using Octokit.Webhooks.Converter;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.Discussion)]
    [JsonConverter(typeof(WebhookConverter<DiscussionEvent>))]
    public abstract record DiscussionEvent : WebhookEvent
    {
        [JsonPropertyName("discussion")]
        public Models.Discussion Discussion { get; init; }
    }
}
