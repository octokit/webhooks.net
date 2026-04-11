namespace Octokit.Webhooks.Events.ProjectsV2Project;

[PublicAPI]
[WebhookActionType(ProjectsV2ProjectActionValue.Deleted)]
public sealed record ProjectsV2ProjectDeletedEvent : ProjectsV2ProjectEvent
{
    [JsonPropertyName("action")]
    public override string Action => ProjectsV2ProjectAction.Deleted;
}
