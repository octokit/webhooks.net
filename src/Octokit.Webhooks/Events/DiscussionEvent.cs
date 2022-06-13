namespace Octokit.Webhooks.Events;

using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Converter;

[PublicAPI]
[WebhookEventType(WebhookEventType.Discussion)]
[JsonConverter(typeof(WebhookConverter<DiscussionEvent>))]
public abstract record DiscussionEvent : WebhookEvent
{
    [JsonPropertyName("discussion")]
    public Models.Discussion Discussion { get; init; } = null!;
}