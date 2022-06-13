namespace Octokit.Webhooks.Events;

using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Converter;

[PublicAPI]
[WebhookEventType(WebhookEventType.DiscussionComment)]
[JsonConverter(typeof(WebhookConverter<DiscussionCommentEvent>))]
public abstract record DiscussionCommentEvent : WebhookEvent
{
    [JsonPropertyName("comment")]
    public Models.DiscussionCommentEvent.DiscussionComment Comment { get; init; } = null!;

    [JsonPropertyName("discussion")]
    public Models.Discussion Discussion { get; init; } = null!;
}