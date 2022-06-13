namespace Octokit.Webhooks.Events.ProjectsV2Item;

using System.Text.Json.Serialization;
using JetBrains.Annotations;

[PublicAPI]
[WebhookActionType(ProjectsV2ItemActionValue.Created)]
public sealed record ProjectsV2ItemCreatedEvent : ProjectsV2ItemEvent
{
    [JsonPropertyName("action")]
    public override string Action => ProjectsV2ItemAction.Created;
}
