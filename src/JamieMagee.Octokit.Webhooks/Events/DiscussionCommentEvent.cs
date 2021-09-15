namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.DiscussionComment)]
    [JsonConverter(typeof(WebhookConverter<DiscussionCommentEvent>))]
    public abstract record DiscussionCommentEvent : WebhookEvent
    {
        [JsonPropertyName("comment")]
        public Models.DiscussionCommentEvent.DiscussionComment Comment { get; init; }

        [JsonPropertyName("discussion")]
        public Models.Discussion Discussion { get; init; }
    }
}
