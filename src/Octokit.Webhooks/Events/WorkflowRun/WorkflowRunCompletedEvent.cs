namespace Octokit.Webhooks.Events.WorkflowRun;

[PublicAPI]
[WebhookActionType(WorkflowRunActionValue.Completed)]
public sealed record WorkflowRunCompletedEvent : WorkflowRunEvent
{
    [JsonPropertyName("action")]
    public override string Action => WorkflowRunAction.Completed;
}
