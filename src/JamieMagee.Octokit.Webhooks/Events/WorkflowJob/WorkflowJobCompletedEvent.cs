namespace JamieMagee.Octokit.Webhooks.Events.WorkflowJob
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    [WebhookActionType(WorkflowJobActionValue.Completed)]
    public sealed record WorkflowJobCompletedEvent : WorkflowJobEvent
    {
        [JsonPropertyName("action")]
        public override string Action => WorkflowJobAction.Completed;
    }
}
