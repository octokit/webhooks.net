namespace Octokit.Webhooks.Events.Project;

[PublicAPI]
[WebhookActionType(ProjectActionValue.Created)]
public sealed record ProjectCreatedEvent : ProjectEvent
{
    [JsonPropertyName("action")]
    public override string Action => ProjectAction.Created;
}
