namespace Octokit.Webhooks.Events.ProjectsV2Project;

[PublicAPI]
[WebhookActionType(ProjectsV2ProjectActionValue.Edited)]
public sealed record ProjectsV2ProjectEditedEvent : ProjectsV2ProjectEvent
{
    [JsonPropertyName("action")]
    public override string Action => ProjectsV2ProjectAction.Edited;

    [JsonPropertyName("changes")]
    public Models.ProjectsV2ProjectEvent.Changes Changes { get; init; } = null!;
}
