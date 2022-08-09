namespace Octokit.Webhooks.Events.ProjectCard;

using Octokit.Webhooks.Models.ProjectCardEvent;

[PublicAPI]
[WebhookActionType(ProjectCardActionValue.Edited)]
public sealed record ProjectCardEditedEvent : ProjectCardEvent
{
    [JsonPropertyName("action")]
    public override string Action => ProjectCardAction.Edited;

    [JsonPropertyName("changes")]
    public Changes Changes { get; init; } = null!;
}
