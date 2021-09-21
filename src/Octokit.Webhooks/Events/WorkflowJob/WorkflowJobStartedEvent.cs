namespace Octokit.Webhooks.Events.WorkflowJob
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookActionType(WorkflowJobActionValue.Started)]
    public sealed record WorkflowJobStartedEvent : WorkflowJobEvent
    {
        [JsonPropertyName("action")]
        public override string Action => WorkflowJobAction.Started;
    }
}
