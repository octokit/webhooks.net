namespace Octokit.Webhooks.Events.ProjectsV2Item;

using Octokit.Webhooks.Models.ProjectsV2ItemEvent;

[PublicAPI]
[WebhookActionType(ProjectsV2ItemActionValue.Reordered)]
public sealed record ProjectsV2ItemReorderedEvent : ProjectsV2ItemEvent
{
    [JsonPropertyName("action")]
    public override string Action => ProjectsV2ItemAction.Reordered;

    [JsonPropertyName("changes")]
    public Changes Changes { get; init; } = null!;
}
