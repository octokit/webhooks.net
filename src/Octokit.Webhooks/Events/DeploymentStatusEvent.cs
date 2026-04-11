namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.DeploymentStatus)]
[JsonConverter(typeof(WebhookConverter<DeploymentStatusEvent>))]
public abstract record DeploymentStatusEvent : WebhookEvent
{
    [JsonPropertyName("deployment_status")]
    public required Models.DeploymentStatusEvent.DeploymentStatus DeploymentStatus { get; init; }

    [JsonPropertyName("deployment")]
    public required Models.DeploymentStatusEvent.Deployment Deployment { get; init; }

    [JsonPropertyName("check_run")]
    public Models.DeploymentEvent.DeploymentCheckRun? CheckRun { get; init; }

    [JsonPropertyName("workflow_run")]
    public Models.DeploymentEvent.DeploymentWorkflowRun? WorkflowRun { get; init; }

    [JsonPropertyName("workflow")]
    public Models.Workflow? Workflow { get; init; }
}
