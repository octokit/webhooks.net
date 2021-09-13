namespace JamieMagee.Octokit.Webhooks.Events.WorkflowRun
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    [WebhookActionType(WorkflowRunActionValue.Completed)]
    public sealed record WorkflowRunCompletedEvent : WorkflowRunEvent
    {
        [JsonPropertyName("action")]
        public override string Action => WorkflowRunAction.Completed;
    }
}
