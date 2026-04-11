namespace Octokit.Webhooks.Events.ProjectsV2StatusUpdate;

[PublicAPI]
[WebhookActionType(ProjectsV2StatusUpdateActionValue.Edited)]
public sealed record ProjectsV2StatusUpdateEditedEvent : ProjectsV2StatusUpdateEvent
{
    [JsonPropertyName("action")]
    public override string Action => ProjectsV2StatusUpdateAction.Edited;

    [JsonPropertyName("changes")]
    public required Models.ProjectsV2StatusUpdateEvent.Changes Changes { get; init; }
}
