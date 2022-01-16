namespace Octokit.Webhooks.Events.WorkflowJob
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(WorkflowJobActionValue.Queued)]
    public sealed record WorkflowJobQueuedEvent : WorkflowJobEvent
    {
        [JsonPropertyName("action")]
        public override string Action => WorkflowJobAction.Queued;
    }
}
