namespace Octokit.Webhooks.Events.WorkflowRun;

[PublicAPI]
[WebhookActionType(WorkflowRunActionValue.Requested)]
public sealed record WorkflowRunRequestedEvent : WorkflowRunEvent
{
    [JsonPropertyName("action")]
    public override string Action => WorkflowRunAction.Requested;
}
