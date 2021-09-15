namespace JamieMagee.Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Converter;
    using JamieMagee.Octokit.Webhooks.Models.CommitCommentEvent;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.CommitComment)]
    [JsonConverter(typeof(WebhookConverter<CommitCommentEvent>))]
    public abstract record CommitCommentEvent : WebhookEvent
    {
        [JsonPropertyName("comment")]
        public Comment Comment { get; init; } = null!;
    }
}
