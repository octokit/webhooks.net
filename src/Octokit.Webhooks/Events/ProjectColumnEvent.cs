namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.ProjectColumn)]
[JsonConverter(typeof(WebhookConverter<ProjectColumnEvent>))]
public abstract record ProjectColumnEvent : WebhookEvent
{
    [JsonPropertyName("project_column")]
    public Models.ProjectColumn ProjectColumn { get; init; } = null!;
}
