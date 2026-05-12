namespace Octokit.Webhooks.Events.ProjectsV2;

[PublicAPI]
[WebhookActionType(ProjectsV2ActionValue.Edited)]
public sealed record ProjectsV2EditedEvent : ProjectsV2Event
{
    [JsonPropertyName("action")]
    public override string Action => ProjectsV2Action.Edited;

    [JsonPropertyName("changes")]
    public required Models.ProjectsV2Event.Changes Changes { get; init; }
}
