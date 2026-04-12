namespace Octokit.Webhooks.Events.MergeQueueEntry;

[PublicAPI]
[WebhookActionType(MergeQueueEntryActionValue.Created)]
public sealed record MergeQueueEntryCreatedEvent : MergeQueueEntryEvent
{
    [JsonPropertyName("action")]
    public override string Action => MergeQueueEntryAction.Created;
}
