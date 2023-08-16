namespace Octokit.Webhooks.Events.MergeQueueEntry;

[PublicAPI]
[WebhookActionType(MergeQueueEntryActionValue.Deleted)]
public record MergeQueueEntryDeletedEvent : MergeQueueEntryEvent
{
    [JsonPropertyName("action")]
    public override string Action => MergeQueueEntryAction.Deleted;
}
