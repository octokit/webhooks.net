namespace Octokit.Webhooks.Events.ProjectCard;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(ProjectCardActionValue.Moved)]
public sealed record ProjectCardMovedEvent : ProjectCardEvent
{
    [JsonPropertyName("action")]
    public override string Action => ProjectCardAction.Moved;
}
