namespace Octokit.Webhooks.Events;

using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Converter;

[PublicAPI]
[WebhookEventType(WebhookEventType.MergeGroup)]
[JsonConverter(typeof(WebhookConverter<MergeGroupEvent>))]
public abstract record MergeGroupEvent : WebhookEvent
{
    [JsonPropertyName("merge_group")]
    public Models.MergeGroupEvent.MergeGroup MergeGroup { get; init; } = null!;
}
