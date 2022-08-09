namespace Octokit.Webhooks.Events.ProjectColumn;

[PublicAPI]
[WebhookActionType(ProjectColumnActionValue.Moved)]
public sealed record ProjectColumnMovedEvent : ProjectColumnEvent
{
    [JsonPropertyName("action")]
    public override string Action => ProjectColumnAction.Moved;
}
