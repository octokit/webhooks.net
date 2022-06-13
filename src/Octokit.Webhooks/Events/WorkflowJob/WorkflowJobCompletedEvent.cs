namespace Octokit.Webhooks.Events.WorkflowJob;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(WorkflowJobActionValue.Completed)]
public sealed record WorkflowJobCompletedEvent : WorkflowJobEvent
{
    [JsonPropertyName("action")]
    public override string Action => WorkflowJobAction.Completed;
}