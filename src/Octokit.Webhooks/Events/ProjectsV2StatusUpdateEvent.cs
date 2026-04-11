namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.ProjectsV2StatusUpdate)]
[JsonConverter(typeof(WebhookConverter<ProjectsV2StatusUpdateEvent>))]
public abstract record ProjectsV2StatusUpdateEvent : WebhookEvent
{
    [JsonPropertyName("projects_v2_status_update")]
    public Models.ProjectsV2StatusUpdateEvent.ProjectsV2StatusUpdate ProjectsV2StatusUpdate { get; init; } = null!;
}
