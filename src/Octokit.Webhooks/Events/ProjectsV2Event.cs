namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.ProjectsV2)]
[JsonConverter(typeof(WebhookConverter<ProjectsV2Event>))]
public abstract record ProjectsV2Event : WebhookEvent
{
    [JsonPropertyName("projects_v2")]
    public required Models.ProjectsV2Event.ProjectsV2 ProjectsV2 { get; init; }
}
