namespace Octokit.Webhooks.Events.ProjectColumn;

using Octokit.Webhooks.Models.ProjectColumnEvent;

[PublicAPI]
[WebhookActionType(ProjectColumnActionValue.Edited)]
public sealed record ProjectColumnEditedEvent : ProjectColumnEvent
{
    [JsonPropertyName("action")]
    public override string Action => ProjectColumnAction.Edited;

    [JsonPropertyName("changes")]
    public Changes Changes { get; init; } = null!;
}
