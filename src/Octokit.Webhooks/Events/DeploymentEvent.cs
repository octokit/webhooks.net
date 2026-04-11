namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.Deployment)]
[JsonConverter(typeof(WebhookConverter<DeploymentEvent>))]
public abstract record DeploymentEvent : WebhookEvent
{
    [JsonPropertyName("deployment")]
    public required Models.DeploymentEvent.Deployment Deployment { get; init; }

    [JsonPropertyName("workflow")]
    public Models.Workflow? Workflow { get; init; }

    [JsonPropertyName("workflow_run")]
    public Models.DeploymentEvent.DeploymentWorkflowRun? WorkflowRun { get; init; }
}
