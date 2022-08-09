namespace Octokit.Webhooks.Events.ProjectColumn;

[PublicAPI]
[WebhookActionType(ProjectColumnActionValue.Created)]
public sealed record ProjectColumnCreatedEvent : ProjectColumnEvent
{
    [JsonPropertyName("action")]
    public override string Action => ProjectColumnAction.Created;
}
