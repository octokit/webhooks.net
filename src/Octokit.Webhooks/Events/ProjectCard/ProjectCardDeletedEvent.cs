namespace Octokit.Webhooks.Events.ProjectCard;

[PublicAPI]
[WebhookActionType(ProjectCardActionValue.Deleted)]
public sealed record ProjectCardDeletedEvent : ProjectCardEvent
{
    [JsonPropertyName("action")]
    public override string Action => ProjectCardAction.Deleted;
}
