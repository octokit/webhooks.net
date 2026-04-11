namespace Octokit.Webhooks.Events.ProjectsV2Project;

[PublicAPI]
[WebhookActionType(ProjectsV2ProjectActionValue.Created)]
public sealed record ProjectsV2ProjectCreatedEvent : ProjectsV2ProjectEvent
{
    [JsonPropertyName("action")]
    public override string Action => ProjectsV2ProjectAction.Created;
}
