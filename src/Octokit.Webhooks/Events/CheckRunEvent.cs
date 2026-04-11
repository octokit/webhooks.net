namespace Octokit.Webhooks.Events;

using Octokit.Webhooks.Models.CheckRunEvent;

[PublicAPI]
[WebhookEventType(WebhookEventType.CheckRun)]
[JsonConverter(typeof(WebhookConverter<CheckRunEvent>))]
public abstract record CheckRunEvent : WebhookEvent
{
    [JsonPropertyName("check_run")]
    public required Models.CheckRunEvent.CheckRun CheckRun { get; init; }

    [JsonPropertyName("requested_action")]
    public RequestedAction? RequestedAction { get; init; }
}
