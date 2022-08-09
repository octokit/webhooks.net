namespace Octokit.Webhooks.Events.Project;

[PublicAPI]
[WebhookActionType(ProjectActionValue.Deleted)]
public sealed record ProjectDeletedEvent : ProjectEvent
{
    [JsonPropertyName("action")]
    public override string Action => ProjectAction.Deleted;
}
