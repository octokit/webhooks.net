namespace Octokit.Webhooks.Events.ProjectsV2Item;

using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Models.ProjectsV2ItemEvent;

[PublicAPI]
[WebhookActionType(ProjectsV2ItemActionValue.Restored)]
public sealed record ProjectsV2ItemRestoredEvent : ProjectsV2ItemEvent
{
    [JsonPropertyName("action")]
    public override string Action => ProjectsV2ItemAction.Restored;

    [JsonPropertyName("changes")]
    public Changes Changes { get; init; } = null!;
}
