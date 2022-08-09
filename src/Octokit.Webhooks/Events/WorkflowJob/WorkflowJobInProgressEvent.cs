namespace Octokit.Webhooks.Events.WorkflowJob;

[PublicAPI]
[WebhookActionType(WorkflowJobActionValue.InProgress)]
public sealed record WorkflowJobInProgressEvent : WorkflowJobEvent
{
    [JsonPropertyName("action")]
    public override string Action => WorkflowJobAction.InProgress;
}
