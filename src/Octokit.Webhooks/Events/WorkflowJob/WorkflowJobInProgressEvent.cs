namespace Octokit.Webhooks.Events.WorkflowJob;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(WorkflowJobActionValue.InProgress)]
public sealed record WorkflowJobInProgressEvent : WorkflowJobEvent
{
    [JsonPropertyName("action")]
    public override string Action => WorkflowJobAction.InProgress;
}
