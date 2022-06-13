namespace Octokit.Webhooks.Events.WorkflowRun;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(WorkflowRunActionValue.Requested)]
public sealed record WorkflowRunRequestedEvent : WorkflowRunEvent
{
    [JsonPropertyName("action")]
    public override string Action => WorkflowRunAction.Requested;
}