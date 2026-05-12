namespace Octokit.Webhooks.Events.ProjectsV2;

[PublicAPI]
[WebhookActionType(ProjectsV2ActionValue.Closed)]
public sealed record ProjectsV2ClosedEvent : ProjectsV2Event
{
    [JsonPropertyName("action")]
    public override string Action => ProjectsV2Action.Closed;
}
