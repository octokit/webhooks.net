namespace Octokit.Webhooks.Events.ProjectsV2;

[PublicAPI]
[WebhookActionType(ProjectsV2ActionValue.Created)]
public sealed record ProjectsV2CreatedEvent : ProjectsV2Event
{
    [JsonPropertyName("action")]
    public override string Action => ProjectsV2Action.Created;
}
