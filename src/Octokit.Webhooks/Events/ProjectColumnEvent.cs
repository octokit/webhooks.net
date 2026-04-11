namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.ProjectColumn)]
[JsonConverter(typeof(WebhookConverter<ProjectColumnEvent>))]
public abstract record ProjectColumnEvent : WebhookEvent
{
    [JsonPropertyName("project_column")]
    public required Models.ProjectColumn ProjectColumn { get; init; }
}
