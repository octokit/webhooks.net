namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.MergeGroup)]
[JsonConverter(typeof(WebhookConverter<MergeGroupEvent>))]
public abstract record MergeGroupEvent : WebhookEvent
{
    [JsonPropertyName("merge_group")]
    public Models.MergeGroupEvent.MergeGroup MergeGroup { get; init; } = null!;
}
