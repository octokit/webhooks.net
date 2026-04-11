namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.ProjectCard)]
[JsonConverter(typeof(WebhookConverter<ProjectCardEvent>))]
public abstract record ProjectCardEvent : WebhookEvent
{
    [JsonPropertyName("project_card")]
    public required Models.ProjectCard ProjectCard { get; init; }
}
