namespace Octokit.Webhooks.Events
{
    using System.Text.Json.Serialization;
    using JetBrains.Annotations;

    [PublicAPI]
    [WebhookEventType(WebhookEventType.WorkflowDispatch)]
    public sealed record WorkflowDispatchEvent : WebhookEvent
    {
        [JsonPropertyName("inputs")]
        public dynamic? Inputs { get; init; }

        [JsonPropertyName("ref")]
        public string Ref { get; init; } = null!;

        [JsonPropertyName("workflow")]
        public string Workflow { get; init; } = null!;
    }
}
