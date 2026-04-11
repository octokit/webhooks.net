namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.WorkflowDispatch)]
public sealed record WorkflowDispatchEvent : WebhookEvent
{
    [JsonPropertyName("inputs")]
    public IDictionary<string, JsonElement>? Inputs { get; init; }

    [JsonPropertyName("ref")]
    public required string Ref { get; init; }

    [JsonPropertyName("workflow")]
    public required string Workflow { get; init; }
}
