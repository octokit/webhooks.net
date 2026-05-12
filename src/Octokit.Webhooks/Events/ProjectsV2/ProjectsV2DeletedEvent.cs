namespace Octokit.Webhooks.Events.ProjectsV2;

[PublicAPI]
[WebhookActionType(ProjectsV2ActionValue.Deleted)]
public sealed record ProjectsV2DeletedEvent : ProjectsV2Event
{
    [JsonPropertyName("action")]
    public override string Action => ProjectsV2Action.Deleted;
}
