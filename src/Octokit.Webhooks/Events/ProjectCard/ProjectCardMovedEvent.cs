namespace Octokit.Webhooks.Events.ProjectCard;

using Octokit.Webhooks.Models.ProjectCardEvent;

[PublicAPI]
[WebhookActionType(ProjectCardActionValue.Moved)]
public sealed record ProjectCardMovedEvent : ProjectCardEvent
{
    [JsonPropertyName("action")]
    public override string Action => ProjectCardAction.Moved;

    [JsonPropertyName("changes")]
    public Changes? Changes { get; init; }
}
