namespace Octokit.Webhooks.Events.ProjectsV2;

[PublicAPI]
[WebhookActionType(ProjectsV2ActionValue.Reopened)]
public sealed record ProjectsV2ReopenedEvent : ProjectsV2Event
{
    [JsonPropertyName("action")]
    public override string Action => ProjectsV2Action.Reopened;
}
