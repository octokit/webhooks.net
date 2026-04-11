namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.WorkflowRun)]
[JsonConverter(typeof(WebhookConverter<WorkflowRunEvent>))]
public abstract record WorkflowRunEvent : WebhookEvent
{
    [JsonPropertyName("workflow")]
    public required Workflow Workflow { get; init; }

    [JsonPropertyName("workflow_run")]
    public required Models.WorkflowRun WorkflowRun { get; init; }
}
