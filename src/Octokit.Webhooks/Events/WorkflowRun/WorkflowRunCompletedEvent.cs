namespace Octokit.Webhooks.Events.WorkflowRun;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(WorkflowRunActionValue.Completed)]
public sealed record WorkflowRunCompletedEvent : WorkflowRunEvent
{
    [JsonPropertyName("action")]
    public override string Action => WorkflowRunAction.Completed;
}