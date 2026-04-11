namespace Octokit.Webhooks.Events.ProjectsV2StatusUpdate;

[PublicAPI]
[WebhookActionType(ProjectsV2StatusUpdateActionValue.Deleted)]
public sealed record ProjectsV2StatusUpdateDeletedEvent : ProjectsV2StatusUpdateEvent
{
    [JsonPropertyName("action")]
    public override string Action => ProjectsV2StatusUpdateAction.Deleted;
}
