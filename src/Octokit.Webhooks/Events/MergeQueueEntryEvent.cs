namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.MergeQueueEntry)]
[JsonConverter(typeof(WebhookConverter<MergeQueueEntryEvent>))]
public abstract record MergeQueueEntryEvent : WebhookEvent;
