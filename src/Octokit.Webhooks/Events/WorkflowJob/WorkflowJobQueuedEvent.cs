namespace Octokit.Webhooks.Events.WorkflowJob;

[PublicAPI]
[WebhookActionType(WorkflowJobActionValue.Queued)]
public sealed record WorkflowJobQueuedEvent : WorkflowJobEvent
{
    [JsonPropertyName("action")]
    public override string Action => WorkflowJobAction.Queued;
}
