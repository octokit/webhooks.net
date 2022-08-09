namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.DeploymentStatus)]
[JsonConverter(typeof(WebhookConverter<DeploymentStatusEvent>))]
public abstract record DeploymentStatusEvent : WebhookEvent
{
    [JsonPropertyName("deployment_status")]
    public Models.DeploymentStatusEvent.DeploymentStatus DeploymentStatus { get; init; } = null!;

    [JsonPropertyName("deployment")]
    public Models.DeploymentStatusEvent.Deployment Deployment { get; init; } = null!;

    [JsonPropertyName("check_run")]
    public Models.DeploymentEvent.DeploymentCheckRun? CheckRun { get; init; }

    [JsonPropertyName("workflow_run")]
    public Models.DeploymentEvent.DeploymentWorkflowRun? WorkflowRun { get; init; }

    [JsonPropertyName("workflow")]
    public Models.Workflow? Workflow { get; init; }
}
