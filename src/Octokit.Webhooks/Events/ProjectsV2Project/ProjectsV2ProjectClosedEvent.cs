namespace Octokit.Webhooks.Events.ProjectsV2Project;

[PublicAPI]
[WebhookActionType(ProjectsV2ProjectActionValue.Closed)]
public sealed record ProjectsV2ProjectClosedEvent : ProjectsV2ProjectEvent
{
    [JsonPropertyName("action")]
    public override string Action => ProjectsV2ProjectAction.Closed;
}
