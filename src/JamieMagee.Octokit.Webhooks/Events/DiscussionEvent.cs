namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;

    [WebhookEventType(WebhookEventType.Discussion)]
    [JsonConverter(typeof(WebhookConverter<DiscussionEvent>))]
    public abstract record DiscussionEvent : WebhookEvent
    {
        [JsonPropertyName("discussion")]
        public Models.Discussion Discussion { get; init; }
    }
}
