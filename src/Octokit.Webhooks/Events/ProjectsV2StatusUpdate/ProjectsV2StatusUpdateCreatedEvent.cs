namespace Octokit.Webhooks.Events.ProjectsV2StatusUpdate;

[PublicAPI]
[WebhookActionType(ProjectsV2StatusUpdateActionValue.Created)]
public sealed record ProjectsV2StatusUpdateCreatedEvent : ProjectsV2StatusUpdateEvent
{
    [JsonPropertyName("action")]
    public override string Action => ProjectsV2StatusUpdateAction.Created;
}
