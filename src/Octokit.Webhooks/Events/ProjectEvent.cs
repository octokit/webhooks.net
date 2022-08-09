namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.Project)]
[JsonConverter(typeof(WebhookConverter<ProjectEvent>))]
public abstract record ProjectEvent : WebhookEvent
{
    [JsonPropertyName("project")]
    public Models.Project Project { get; init; } = null!;
}
