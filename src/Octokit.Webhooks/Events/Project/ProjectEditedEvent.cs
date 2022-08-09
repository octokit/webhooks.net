namespace Octokit.Webhooks.Events.Project;

using Octokit.Webhooks.Models.ProjectEvent;

[PublicAPI]
[WebhookActionType(ProjectActionValue.Edited)]
public sealed record ProjectEditedEvent : ProjectEvent
{
    [JsonPropertyName("action")]
    public override string Action => ProjectAction.Edited;

    [JsonPropertyName("changes")]
    public Changes Changes { get; init; } = null!;
}
