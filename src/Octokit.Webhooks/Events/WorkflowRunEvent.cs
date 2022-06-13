namespace Octokit.Webhooks.Events;

using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Converter;
using Octokit.Webhooks.Models;

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
