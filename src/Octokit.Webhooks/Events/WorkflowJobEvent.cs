namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.WorkflowJob)]
[JsonConverter(typeof(WebhookConverter<WorkflowJobEvent>))]
public abstract record WorkflowJobEvent : WebhookEvent
{
    [JsonPropertyName("workflow_job")]
    public Models.WorkflowJobEvent.WorkflowJob WorkflowJob { get; init; } = null!;
}
