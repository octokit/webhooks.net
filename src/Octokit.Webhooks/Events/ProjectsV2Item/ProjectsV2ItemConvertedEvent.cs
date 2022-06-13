namespace Octokit.Webhooks.Events.ProjectsV2Item;

using System.Text.Json.Serialization;
using JetBrains.Annotations;
using Octokit.Webhooks.Models.ProjectsV2ItemEvent;

[PublicAPI]
[WebhookActionType(ProjectsV2ItemActionValue.Converted)]
public sealed record ProjectsV2ItemConvertedEvent : ProjectsV2ItemEvent
{
    [JsonPropertyName("action")]
    public override string Action => ProjectsV2ItemAction.Converted;

    [JsonPropertyName("changes")]
    public Changes Changes { get; init; } = null!;
}