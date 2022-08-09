namespace Octokit.Webhooks.Events;

[PublicAPI]
[WebhookEventType(WebhookEventType.ProjectsV2Item)]
[JsonConverter(typeof(WebhookConverter<ProjectsV2ItemEvent>))]
public abstract record ProjectsV2ItemEvent : WebhookEvent
{
    [JsonPropertyName("projects_v2_item")]
    public Models.ProjectsV2Item ProjectsV2Item { get; init; } = null!;
}
