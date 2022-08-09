namespace Octokit.Webhooks.Events.ProjectColumn;

[PublicAPI]
[WebhookActionType(ProjectColumnActionValue.Deleted)]
public sealed record ProjectColumnDeletedEvent : ProjectColumnEvent
{
    [JsonPropertyName("action")]
    public override string Action => ProjectColumnAction.Deleted;
}
