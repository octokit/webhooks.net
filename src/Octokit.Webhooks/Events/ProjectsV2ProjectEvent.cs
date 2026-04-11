namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.ProjectsV2Project)]
[JsonConverter(typeof(WebhookConverter<ProjectsV2ProjectEvent>))]
public abstract record ProjectsV2ProjectEvent : WebhookEvent
{
    [JsonPropertyName("projects_v2")]
    public required Models.ProjectsV2ProjectEvent.ProjectsV2 ProjectsV2 { get; init; }
}
