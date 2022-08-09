namespace Octokit.Webhooks.Events.ProjectsV2Item;

[PublicAPI]
[WebhookActionType(ProjectsV2ItemActionValue.Deleted)]
public sealed record ProjectsV2ItemDeletedEvent : ProjectsV2ItemEvent
{
    [JsonPropertyName("action")]
    public override string Action => ProjectsV2ItemAction.Deleted;
}
