namespace Octokit.Webhooks.Events.WorkflowRun;

[PublicAPI]
[WebhookActionType(WorkflowRunActionValue.InProgress)]
public sealed record WorkflowRunInProgressEvent : WorkflowRunEvent
{
    [JsonPropertyName("action")]
    public override string Action => WorkflowRunAction.InProgress;
}
