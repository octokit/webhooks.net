namespace JamieMagee.Octokit.Webhooks.Events.WorkflowRun
{
    using System.Text.Json.Serialization;
    using JamieMagee.Octokit.Webhooks.Models;

    public sealed record WorkflowRunRequestedEvent : WorkflowRunEvent
    {
        [JsonPropertyName("action")]
        public override string Action => WorkflowRunAction.Requested;
    }
}
