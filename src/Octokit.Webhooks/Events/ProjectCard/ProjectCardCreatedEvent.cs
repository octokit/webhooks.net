namespace Octokit.Webhooks.Events.ProjectCard;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(ProjectCardActionValue.Created)]
public sealed record ProjectCardCreatedEvent : ProjectCardEvent
{
    [JsonPropertyName("action")]
    public override string Action => ProjectCardAction.Created;
}
