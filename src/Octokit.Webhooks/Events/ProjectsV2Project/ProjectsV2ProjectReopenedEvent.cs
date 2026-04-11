namespace Octokit.Webhooks.Events.ProjectsV2Project;

[PublicAPI]
[WebhookActionType(ProjectsV2ProjectActionValue.Reopened)]
public sealed record ProjectsV2ProjectReopenedEvent : ProjectsV2ProjectEvent
{
    [JsonPropertyName("action")]
    public override string Action => ProjectsV2ProjectAction.Reopened;
}
