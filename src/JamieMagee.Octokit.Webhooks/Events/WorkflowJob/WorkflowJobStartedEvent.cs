namespace JamieMagee.Octokit.Webhooks.Events.WorkflowJob
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    [WebhookActionType(WorkflowJobActionValue.Started)]
    public sealed record WorkflowJobStartedEvent : WorkflowJobEvent
    {
        [JsonPropertyName("action")]
        public override string Action => WorkflowJobAction.Started;
    }
}
