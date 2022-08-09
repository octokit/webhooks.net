namespace Octokit.Webhooks.Events.Project;

[PublicAPI]
[WebhookActionType(ProjectActionValue.Reopened)]
public sealed record ProjectReopenedEvent : ProjectEvent
{
    [JsonPropertyName("action")]
    public override string Action => ProjectAction.Reopened;
}
