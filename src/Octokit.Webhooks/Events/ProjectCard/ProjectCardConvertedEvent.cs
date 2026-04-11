namespace Octokit.Webhooks.Events.ProjectCard;

using Octokit.Webhooks.Models.ProjectCardEvent;

[PublicAPI]
[WebhookActionType(ProjectCardActionValue.Converted)]
public sealed record ProjectCardConvertedEvent : ProjectCardEvent
{
    [JsonPropertyName("action")]
    public override string Action => ProjectCardAction.Converted;

    [JsonPropertyName("changes")]
    public required Changes Changes { get; init; }
}
