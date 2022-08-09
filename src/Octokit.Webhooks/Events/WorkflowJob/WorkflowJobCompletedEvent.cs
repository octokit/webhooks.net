namespace Octokit.Webhooks.Events.WorkflowJob;

[PublicAPI]
[WebhookActionType(WorkflowJobActionValue.Completed)]
public sealed record WorkflowJobCompletedEvent : WorkflowJobEvent
{
    [JsonPropertyName("action")]
    public override string Action => WorkflowJobAction.Completed;
}
