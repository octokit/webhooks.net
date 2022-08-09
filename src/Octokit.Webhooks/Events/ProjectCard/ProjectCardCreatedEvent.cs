namespace Octokit.Webhooks.Events.ProjectCard;

[PublicAPI]
[WebhookActionType(ProjectCardActionValue.Created)]
public sealed record ProjectCardCreatedEvent : ProjectCardEvent
{
    [JsonPropertyName("action")]
    public override string Action => ProjectCardAction.Created;
}
