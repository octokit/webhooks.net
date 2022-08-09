namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.WorkflowRun)]
[JsonConverter(typeof(WebhookConverter<WorkflowRunEvent>))]
public abstract record WorkflowRunEvent : WebhookEvent
{
    [JsonPropertyName("workflow")]
    public Workflow Workflow { get; init; } = null!;

    [JsonPropertyName("workflow_run")]
    public Models.WorkflowRun WorkflowRun { get; init; } = null!;
}
