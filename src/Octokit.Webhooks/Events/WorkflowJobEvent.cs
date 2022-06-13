namespace Octokit.Webhooks.Events;

using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Converter;

[PublicAPI]
[WebhookEventType(WebhookEventType.WorkflowJob)]
[JsonConverter(typeof(WebhookConverter<WorkflowJobEvent>))]
public abstract record WorkflowJobEvent : WebhookEvent
{
    [JsonPropertyName("workflow_job")]
    public Models.WorkflowJobEvent.WorkflowJob WorkflowJob { get; init; } = null!;
}
