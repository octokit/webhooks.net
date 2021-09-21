namespace Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using Octokit.Webhooks.Converter;
    using Octokit.Webhooks.Models.CommitCommentEvent;
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
