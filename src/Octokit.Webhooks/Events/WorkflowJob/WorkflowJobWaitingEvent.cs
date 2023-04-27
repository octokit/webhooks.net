namespace Octokit.Webhooks.Events.WorkflowJob;

[PublicAPI]
[WebhookActionType(WorkflowJobActionValue.Waiting)]
public sealed record WorkflowJobWaitingEvent : WorkflowJobEvent
{
    [JsonPropertyName("action")]
    public override string Action => WorkflowJobAction.Waiting;
}
